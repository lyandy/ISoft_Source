using System;
using System.Web;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;

namespace AutoUpdate
{
	/// <summary>
	/// updater 的摘要说明。
	/// </summary>
	public class AppUpdater:IDisposable
	{
		#region 成员与字段属性
		private string _updaterUrl;
        private string _updaterUrl1;
		private bool disposed = false;
		private IntPtr handle;
		private Component component = new Component();
		[System.Runtime.InteropServices.DllImport("Kernel32")]
		private extern static Boolean CloseHandle(IntPtr handle);


		public string UpdaterUrl
		{
			set{_updaterUrl = value;}
			get{return this._updaterUrl;}
		}

        public string UpdaterUrl1
        {
            set { _updaterUrl1 = value; }
            get { return this._updaterUrl1; }
        }
		#endregion

		/// <summary>
		/// AppUpdater构造函数
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		private void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				if(disposing)
				{
				
					component.Dispose();
				}
				CloseHandle(handle);
				handle = IntPtr.Zero;            
			}
			disposed = true;         
		}

		~AppUpdater()      
		{
			Dispose(false);
		}


		/// <summary>
		/// 检查更新文件
		/// </summary>
		/// <param name="serverXmlFile"></param>
		/// <param name="localXmlFile"></param>
		/// <param name="updateFileList"></param>
		/// <returns></returns>
		public int CheckForUpdate(string serverXmlFile,string localXmlFile,out Hashtable updateFileList)
		{
			updateFileList = new Hashtable();
			if(!File.Exists(localXmlFile) || !File.Exists(serverXmlFile))
			{
				return -1;
			}
			
			XmlFiles serverXmlFiles = new XmlFiles(serverXmlFile);
			XmlFiles localXmlFiles = new XmlFiles(localXmlFile);
			
			XmlNodeList newNodeList = serverXmlFiles.GetNodeList("AutoUpdater/Files");
			XmlNodeList oldNodeList = localXmlFiles.GetNodeList("AutoUpdater/Files");//5+1+a+s+p+x

			int k = 0;
			for(int i = 0;i < newNodeList.Count;i++)
			{
				string [] fileList = new string[4];

				string newFileName = newNodeList.Item(i).Attributes["Name"].Value.Trim();
				string newVer = newNodeList.Item(i).Attributes["Ver"].Value.Trim();
                string newUpdateTxt = newNodeList.Item(i).Attributes["UpdateTxt"].Value.Trim();
				
				ArrayList oldFileAl = new ArrayList();
				for(int j = 0;j < oldNodeList.Count;j++)
				{
					string oldFileName = oldNodeList.Item(j).Attributes["Name"].Value.Trim();
					string oldVer = oldNodeList.Item(j).Attributes["Ver"].Value.Trim();
                    string oldUpdateTxt = oldNodeList.Item(j).Attributes["UpdateTxt"].Value.Trim();
					
					oldFileAl.Add(oldFileName);
					oldFileAl.Add(oldVer);

				}
				int pos = oldFileAl.IndexOf(newFileName);
				if(pos == -1)
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
                    fileList[3] = newUpdateTxt;
					updateFileList.Add(k,fileList);
					k++;
				}
				else if(pos > -1 && newVer.CompareTo(oldFileAl[pos+1].ToString())>0 )
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
                    fileList[3] = newUpdateTxt;
					updateFileList.Add(k,fileList);
					k++;
				}
				
			}
			return k;
		}
	
		/// <summary>
		/// 检查更新文件
		/// </summary>
		/// <param name="serverXmlFile"></param>
		/// <param name="localXmlFile"></param>
		/// <param name="updateFileList"></param>
		/// <returns></returns>
		public int CheckForUpdate()
		{
			string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
			if(!File.Exists(localXmlFile))
			{
				return -1;
			}

			XmlFiles updaterXmlFiles = new XmlFiles(localXmlFile );


			string tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\"+ "_"+ updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value+"_"+"y"+"_"+"x"+"_"+"m"+"_"+"\\";
			this.UpdaterUrl = updaterXmlFiles.GetNodeValue("//Url") + "/UpdateList.xml";
			this.DownAutoUpdateFile(tempUpdatePath);

			string serverXmlFile = tempUpdatePath  +"\\UpdateList.xml";
			if(!File.Exists(serverXmlFile))
			{
				return -1;
			}
			
			XmlFiles serverXmlFiles = new XmlFiles(serverXmlFile);
			XmlFiles localXmlFiles = new XmlFiles(localXmlFile);
			
			XmlNodeList newNodeList = serverXmlFiles.GetNodeList("AutoUpdater/Files");
			XmlNodeList oldNodeList = localXmlFiles.GetNodeList("AutoUpdater/Files");

			int k = 0;
			for(int i = 0;i < newNodeList.Count;i++)
			{
				string [] fileList = new string[3];

				string newFileName = newNodeList.Item(i).Attributes["Name"].Value.Trim();
				string newVer = newNodeList.Item(i).Attributes["Ver"].Value.Trim();
				
				ArrayList oldFileAl = new ArrayList();
				for(int j = 0;j < oldNodeList.Count;j++)
				{
					string oldFileName = oldNodeList.Item(j).Attributes["Name"].Value.Trim();
					string oldVer = oldNodeList.Item(j).Attributes["Ver"].Value.Trim();
					
					oldFileAl.Add(oldFileName);
					oldFileAl.Add(oldVer);

				}
				int pos = oldFileAl.IndexOf(newFileName);
				if(pos == -1)
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
					k++;
				}
				else if(pos > -1 && newVer.CompareTo(oldFileAl[pos+1].ToString())>0 )
				{
					fileList[0] = newFileName;
					fileList[1] = newVer;
					k++;
				}
				
			}
			return k;
		}
		/// <summary>
		/// 返回下载更新文件的临时目录
		/// </summary>
		/// <returns></returns>
		public void DownAutoUpdateFile(string downpath)
		{
			if(!System.IO.Directory.Exists(downpath))
				System.IO.Directory.CreateDirectory(downpath);
			string serverXmlFile = downpath+@"/UpdateList.xml";
            string serverXmlFile1 = downpath + @"/Update.xml";

			try
			{
				WebRequest req = WebRequest.Create(this.UpdaterUrl);
				WebResponse res = req.GetResponse();
				if(res.ContentLength >0)
				{
					try
					{
						WebClient wClient = new WebClient();
						wClient.DownloadFile(this.UpdaterUrl,serverXmlFile);
                        wClient.DownloadFile(this.UpdaterUrl1, serverXmlFile1);
					}
					catch
					{
						return;
					}
				}
			}
			catch
			{
				return;
			}
			//return tempPath;
		}
	}
}

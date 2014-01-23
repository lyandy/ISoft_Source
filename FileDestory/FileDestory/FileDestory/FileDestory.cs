using System;
using System.IO;
using System.Text;

namespace FileDestory 
{
	public class FileDestory 
	{
		public FileDestory(string path) 
		{
			//Console.WriteLine("请输入要粉碎的文件,支持拖拽:");
			//String path = Console.ReadLine();
			FileStream filestream=null;
			BinaryWriter objBinaryWriter=null;
			try
			{
				if (File.Exists(path))
				{
					try
					{
						//打开文件
						filestream=new FileStream(path,FileMode.Create);

						///setAccessControl.ReadAndWrite
						///

						//建立写入文件流
						objBinaryWriter = new BinaryWriter(filestream);
						//以字节流方式写入文件
						
						byte [] filecontent=new UTF8Encoding(true).GetBytes("");
						//path.Length可以直接读取已接收文件的物理长度	
						for(int index =0; index<path.Length;index++)
						{
							objBinaryWriter.Write(filecontent);
						}
						Console.WriteLine("文件已经粉碎");
						
						try
						{
							
							//关闭文件操作流
							objBinaryWriter.Close();
							filestream.Close();
						}
						catch(Exception)
						{
							Console.WriteLine("未能有效闭合文件流");
						}		
						//删除文件
						File.Delete(path);

					}
					catch(Exception)
					{
						Console.WriteLine("尝试写入文件失败!");
					}

				}
				else
				{
					Console.WriteLine("Inviabled File(s) Specified");
				}
                
			}
			catch (Exception e)
			{
				Console.Out.WriteLine("occured an Exception!" + "\n" + e.Message);
			}        
		}
	}
}
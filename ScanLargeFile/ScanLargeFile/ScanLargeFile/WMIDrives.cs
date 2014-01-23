using System;
using System.Management;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
namespace ScanLargeFile
{
    class WMIDrives
    {
        public WMIDrives()
        {
            GetDriveInfo();
            GetVolumeInfo();
        }
         ArrayList mvarDriveCapacity = new ArrayList();
         ArrayList mvarDriveInterface = new ArrayList();
         ArrayList mvarDriveModelNo = new ArrayList();

        ArrayList mvarVolumeType = new ArrayList();
        ArrayList mvarVolumeLetter = new ArrayList();
        ArrayList mvarVolumeLabel = new ArrayList();
        ArrayList mvarVolumeTotalSize = new ArrayList();
        ArrayList mvarVolumeFreeSpace = new ArrayList();
        ArrayList mvarVolumeUsedSpace = new ArrayList();
        ArrayList mvarVolumePercentFreeSpace = new ArrayList();
        ArrayList mvarVolumeSerialNumber = new ArrayList();
        ArrayList mvarVolumeFileSystem = new ArrayList();
        ArrayList mvarVolumeReady = new ArrayList();    
        
        /// <summary>
         /// 得到驱动器信息
        /// </summary>
        private void GetDriveInfo()
        {
            try
            {
                ManagementObjectCollection.ManagementObjectEnumerator enumerator = null;
                SelectQuery query = new SelectQuery("Win32_DiskDrive");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                try
                {
                    enumerator = searcher.Get().GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        int num = 0;
                        ManagementObject info = (ManagementObject)enumerator.Current;
                        if (info["TotalSectors"] != null)
                        {
                            this.mvarDriveCapacity.Add((double)(ulong.Parse(info["TotalSectors"].ToString()) * uint.Parse(info["BytesPerSector"].ToString())));
                        }
                        else
                        {
                            this.mvarDriveCapacity.Add("Unknown");
                        }
                        if (info["InterfaceType"] != null)
                        {
                            this.mvarDriveInterface.Add(info["InterfaceType"].ToString());
                        }
                        else
                        {
                            this.mvarDriveInterface.Add("Unknown");
                        }
                        if (info["Model"] != null)
                        {
                            this.mvarDriveModelNo.Add(info["Model"].ToString());
                        }
                        else
                        {
                            this.mvarDriveModelNo.Add("Unknown");
                        }
                        num++;
                    }
                }
                finally
                {
                    if (enumerator != null)
                    {
                        enumerator.Dispose();
                    }
                }
            }
            catch
            {
                this.mvarDriveCapacity = null;
                this.mvarDriveInterface = null;
                this.mvarDriveModelNo = null;
            }
        }
        /// <summary>
        /// 得到磁盘信息
        /// </summary>
        private void GetVolumeInfo()
        {
            try
            {
                foreach (DriveInfo info in DriveInfo.GetDrives())
                {
                    this.mvarVolumeLetter.Add(info.RootDirectory.ToString());
                    this.mvarVolumeType.Add(info.DriveType.ToString());
                    if (info.IsReady)
                    {
                        this.mvarVolumeFileSystem.Add(info.DriveFormat.ToString());
                    }
                    else
                    {
                        this.mvarVolumeFileSystem.Add("");
                    }
                    this.mvarVolumeReady.Add(info.IsReady);
                    if (info.IsReady)
                    {
                        this.mvarVolumeLabel.Add(info.VolumeLabel);
                    }
                    else
                    {
                        this.mvarVolumeLabel.Add("");
                    }
                    if (info.IsReady)
                    {
                        this.mvarVolumeTotalSize.Add(((double)info.TotalSize).ToString());
                    }
                    else
                    {
                        this.mvarVolumeTotalSize.Add("");
                    }
                    if (info.IsReady)
                    {
                        this.mvarVolumeFreeSpace.Add(((double)info.TotalFreeSpace).ToString()); 
                    }
                    else
                    {
                        this.mvarVolumeFreeSpace.Add("");
                    }
                    if (info.IsReady)
                    {
                        this.mvarVolumeUsedSpace.Add(((double)info.TotalSize-info.TotalFreeSpace).ToString());
                    }
                    else
                    {
                        this.mvarVolumeUsedSpace.Add("");
                    }
                    if (info.IsReady)
                    {
                        this.mvarVolumePercentFreeSpace.Add(Math.Round(((double)info.TotalFreeSpace/info.TotalSize)*100).ToString()+"%");
                    }
                    else
                    {
                        this.mvarVolumePercentFreeSpace.Add("0%");
                    }
                    if (info.IsReady)
                    {
                        this.mvarVolumeSerialNumber.Add(GetVolumeSerialNumber(info.RootDirectory.ToString()));
                    }
                    else
                    {
                        this.mvarVolumeSerialNumber.Add("");
                    }
                }
            }
            catch
            {
                this.mvarVolumeFileSystem = null;
                this.mvarVolumeFreeSpace = null;
                this.mvarVolumeLetter = null;
                this.mvarVolumePercentFreeSpace = null;
                this.mvarVolumeReady = null;
                this.mvarVolumeTotalSize = null;
                this.mvarVolumeType = null;
                this.mvarVolumeUsedSpace = null;
                this.mvarVolumeLabel = null;
                this.mvarVolumeSerialNumber = null;
            }
        }


        private ArrayList GetCDDrive()
        {
            ArrayList collection2 = new ArrayList();
            try
            {
                ManagementObjectCollection.ManagementObjectEnumerator enumerator=null;
                SelectQuery query = new SelectQuery("Win32_CDROMDrive");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                try
                {
                    enumerator = searcher.Get().GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ManagementObject info = (ManagementObject)enumerator.Current;
                        if (info["Drive"] != null)
                        {
                            collection2.Add(info["Drive"].ToString());
                        }
                    }
                    return collection2;
                }
                finally
                {
                    if (enumerator != null)
                    {
                        enumerator.Dispose();
                    }
                }
            }
            catch
            {
                collection2 = null;
            }
            return collection2;
        }

        private ArrayList GetCDManufacturer()
        {
            ArrayList collection2 = new ArrayList();
            try
            {
                ManagementObjectCollection.ManagementObjectEnumerator enumerator = null;
                SelectQuery query = new SelectQuery("Win32_CDROMDrive");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                try
                {
                    enumerator = searcher.Get().GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ManagementObject info = (ManagementObject)enumerator.Current;
                        if (info["Manufacturer"] != null)
                        {
                            collection2.Add(info["Manufacturer"].ToString());
                        }
                    }
                    return collection2;
                }
                finally
                {
                    if (enumerator != null)
                    {
                        enumerator.Dispose();
                    }
                }
            }
            catch 
            {
                collection2 = null;
            }
            return collection2;
        }

        private ArrayList GetCDMediaSize()
        {
            ArrayList collection2 = new ArrayList();
            try
            {
                ManagementObjectCollection.ManagementObjectEnumerator enumerator = null;
                SelectQuery query = new SelectQuery("Win32_CDROMDrive");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                try
                {
                    enumerator = searcher.Get().GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ManagementObject info = (ManagementObject)enumerator.Current;
                        if (info["Size"] != null)
                        {
                            collection2.Add(GeneralModule.FormatBytes(double.Parse(info["Size"].ToString())));
                        }
                        else
                        {
                            collection2.Add("Blank or No Media");
                        }
                    }
                    return collection2;
                }
                finally
                {
                    if (enumerator != null)
                    {
                        enumerator.Dispose();
                    }
                }
            }
            catch
            {
                collection2 = null;
            }
            return collection2;
        }

        private ArrayList GetCDModel()
        {
            ArrayList collection2 = new ArrayList();
            try
            {
                ManagementObjectCollection.ManagementObjectEnumerator enumerator = null;
                SelectQuery query = new SelectQuery("Win32_CDROMDrive");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                try
                {
                    enumerator = searcher.Get().GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ManagementObject info = (ManagementObject)enumerator.Current;
                        if (info["Name"] != null)
                        {
                            collection2.Add(info["Name"].ToString());
                        }
                    }
                    return collection2;
                }
                finally
                {
                    if (enumerator != null)
                    {
                        enumerator.Dispose();
                    }
                }
            }
            catch 
            {
                collection2 = null;
                   }
            return collection2;
        }

        private ArrayList GetCDRevisionLevel()
        {
            ArrayList collection2 = new ArrayList();
            try
            {
                ManagementObjectCollection.ManagementObjectEnumerator enumerator = null;
                SelectQuery query = new SelectQuery("Win32_CDROMDrive");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                try
                {
                    enumerator = searcher.Get().GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ManagementObject info = (ManagementObject)enumerator.Current;
                        if (info["MfrAssignedRevisionLevel"] != null)
                        {
                            collection2.Add(info["MfrAssignedRevisionLevel"].ToString());
                        }
                        else
                        {
                            if (info["RevisionLevel"] != null)
                            {
                                collection2.Add(info["RevisionLevel"].ToString());
                                continue;
                            }
                            collection2.Add("N/A");
                        }
                    }
                    return collection2;
                }
                finally
                {
                    if (enumerator != null)
                    {
                        enumerator.Dispose();
                    }
                }
            }
            catch
            {
                collection2 = null;
            }
            return collection2;
        }



        [DllImport("kernel32", EntryPoint = "GetVolumeInformationA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int GetVolumeInformation([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpRootPathName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpVolumeNameBuffer, int nVolumeNameSize, ref int lpVolumeSerialNumber, ref int lpMaximumComponentLength, ref int lpFileSystemFlags, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileSystemNameBuffer, int nFileSystemNameSize);
        public static string GetVolumeSerialNumber(string volume)
        {
            string text;
            try
            {
                int lpVolumeSerialNumber=0;
                string lpVolumeNameBuffer = "" ;
                string lpFileSystemNameBuffer ="";
                int lpMaximumComponentLength = 0;
                int lpFileSystemFlags = 0;
                if (GetVolumeInformation(ref volume, ref lpVolumeNameBuffer, 0x20, ref lpVolumeSerialNumber, ref lpMaximumComponentLength, ref lpFileSystemFlags, ref lpFileSystemNameBuffer, 0x20) == 0)
                {
                    return "";
                }
                text = System.Convert.ToString(lpVolumeSerialNumber, 16); 
            }
            catch
            {
                text = "";
                return text;
            }
            return text;
        }


        public ArrayList CDDrive
        {
            get
            {
                return GetCDDrive();
            }
        }

        public ArrayList CDMediaSize
        {
            get
            {
                return GetCDMediaSize();
            }
        }
        public ArrayList CDModel
        {
            get
            {
                return GetCDModel();
            }
        }
        /// <summary>
        /// 驱动器容量
        /// </summary>
        public ArrayList DriveCapacity
        {
            get
            {
                return mvarDriveCapacity;
            }
        }
        /// <summary>
        /// 驱动器接口类型
        /// </summary>
        public ArrayList DriveInterface
        {
            get
            {
                return mvarDriveInterface;
            }
        }
        
        /// <summary>
        /// 驱动器型号
        /// </summary>
        public ArrayList DriveModelNo
        {
            get
            {
                return mvarDriveModelNo;
            }
        }

        /// <summary>
        /// 磁盘卷类型
        /// </summary>
        public ArrayList VolumeType
        {
            get
            {
                return mvarVolumeType;
            }
        }
        /// <summary>
        /// 磁盘卷盘符
        /// </summary>
        public ArrayList VolumeLetter
        {
            get
            {
                return mvarVolumeLetter;
            }
        }
        /// <summary>
        /// 磁盘卷标签
        /// </summary>
        public ArrayList VolumeLabel
        {
            get
            {
                return mvarVolumeLabel;
            }
        }
        /// <summary>
        /// 磁盘卷总容量
        /// </summary>
        public ArrayList VolumeTotalSize
        {
            get
            {
                return mvarVolumeTotalSize;
            }
        }
        /// <summary>
        /// 磁盘卷剩余空间
        /// </summary>
        public ArrayList VolumeFreeSpace
        {
            get
            {
                return mvarVolumeFreeSpace;
            }
        }
        /// <summary>
        /// 磁盘卷己使用空间
        /// </summary>
        public ArrayList  VolumeUsedSpace
        {
            get
            {
                return mvarVolumeUsedSpace;
            }
        }
        /// <summary>
        /// 剩余空间百分比
        /// </summary>
        public ArrayList VolumePercentFreeSpace
        {
            get
            {
                return mvarVolumePercentFreeSpace;
            }
        }
        /// <summary>
        /// 磁盘卷系列号
        /// </summary>
        public ArrayList VolumeSerialNumber
        {
            get
            {
                return mvarVolumeSerialNumber;
            }
        }
        /// <summary>
        /// 磁盘卷格式类型
        /// </summary>
        public ArrayList VolumeFileSystem
        {
            get
            {
                return mvarVolumeFileSystem;
            }
        }
        /// <summary>
        /// 磁盘卷可读情况
        /// </summary>
        public ArrayList VolumeReady
        {
            get
            {
                return mvarVolumeReady;
            }
        }
    }    
}

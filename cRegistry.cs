using Microsoft.Win32;
using System;

namespace LibraryRestorer
{
    public partial class cRegistry
    {
        #region -> PROPIEDADES
        /// <summary>
        /// Carpeta de Objetos 3D
        /// </summary>
        private bool _ThreeDObjects;
        public bool ThreeDObjects { get => _ThreeDObjects; set => _ThreeDObjects = value; }

        /// <summary>
        /// Escritorio
        /// </summary>
        private bool _Desktop;
        public bool Desktop { get => _Desktop; set => _Desktop = value; }

        /// <summary>
        /// Carpeta de Documentos
        /// </summary>
        private bool _Documents;
        public bool Documents { get => _Documents; set => _Documents = value; }

        /// <summary>
        /// Carpeta de Descargas
        /// </summary>
        private bool _Downloads;
        public bool Downloads { get => _Downloads; set => _Downloads = value; }

        /// <summary>
        /// Carpeta de Imágenes
        /// </summary>
        private bool _Pictures;
        public bool Pictures { get => _Pictures; set => _Pictures = value; }

        /// <summary>
        /// Carpeta de Música
        /// </summary>
        private bool _Music;
        public bool Music { get => _Music; set => _Music = value; }

        /// <summary>
        /// Carpeta de Videos
        /// </summary>
        private bool _Videos;
        public bool Videos { get => _Videos; set => _Videos = value; }
        #endregion -> PROPIEDADES

        /// <summary>
        /// Revisa en el registro las carpetas de acceso rápido que están configuradas
        /// </summary>
        /// <remarks>
        /// Fecha: 12.06.2024, Autor: clealz
        /// </remarks>
        public void DetectFoldersEnabled()
        {
            /*
             * Objects3D = "{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}";
                Desk = "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}";
                Docs1 = "{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}";
                Docs2 = "{d3162b92-9365-467a-956b-92703aca08af}";
                Down1 = "{374DE290-123F-4565-9164-39C4925E467B}";
                Down2 = "{088e3905-0323-4b02-9826-5d99428e115f}";
                Img1 = "{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}";
                Img2 = "{24ad3ad4-a569-4530-98e1-ab02f9417aa8}";
                Mus1 = "{1CF1260C-4DD0-4ebb-811F-33C572699FDE}";
                Mus2 = "{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}";
                Vid1 = "{A0953C92-50DC-43bf-BE83-3742FED03C9C}";
                Vid2 = "{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}";
            */
            RegistryKey HKLM;

            HKLM = Environment.Is64BitOperatingSystem
                ? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                : Registry.LocalMachine;

            RegistryKey NameSpace = HKLM.OpenSubKey("SOFTWARE", false)
                .OpenSubKey("Microsoft", false)
                .OpenSubKey("Windows", false)
                .OpenSubKey("CurrentVersion", false)
                .OpenSubKey("Explorer", false)
                .OpenSubKey("MyComputer", false)
                .OpenSubKey("NameSpace", false);

            // Objetos 3D
            if (NameSpace.OpenSubKey("{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}", false) != null)
                ThreeDObjects = true;
            else
                ThreeDObjects = false;
            // Escritorio
            if (NameSpace.OpenSubKey("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", false) != null)
                Desktop = true;
            else
                Desktop = false;
            // Documentos
            if (NameSpace.OpenSubKey("{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}", false) != null)
            {
                if (NameSpace.OpenSubKey("{d3162b92-9365-467a-956b-92703aca08af}", false) != null)
                    Documents = true;
                else
                    Documents = false;
            }
            else
                Documents = false;
            // Descargas
            if (NameSpace.OpenSubKey("{374DE290-123F-4565-9164-39C4925E467B}", false) != null)
            {
                if (NameSpace.OpenSubKey("{088e3905-0323-4b02-9826-5d99428e115f}", false) != null)
                    Downloads = true;
                else
                    Downloads = false;
            }
            else
                Downloads = false;
            // Imagenes
            if (NameSpace.OpenSubKey("{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}", false) != null)
            {
                if (NameSpace.OpenSubKey("{24ad3ad4-a569-4530-98e1-ab02f9417aa8}", false) != null)
                    Pictures = true;
                else
                    Pictures = false;
            }
            else
                Pictures = false;
            // Musica
            if (NameSpace.OpenSubKey("{1CF1260C-4DD0-4ebb-811F-33C572699FDE}", false) != null)
            {
                if (NameSpace.OpenSubKey("{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}", false) != null)
                    Music = true;
                else
                    Music = false;
            }
            else
                Music = false;
            // Videos
            if (NameSpace.OpenSubKey("{A0953C92-50DC-43bf-BE83-3742FED03C9C}", false) != null)
            {
                if (NameSpace.OpenSubKey("{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}", false) != null)
                    Videos = true;
                else
                    Videos = false;
            }
            else
                Videos = false;
        }

        /// <summary>
        /// Agrega o Elimina la Carpeta seleccionada
        /// </summary>
        /// <param name="Folder"></param>
        /// <param name="Value"></param>
        /// <remarks>
        /// Fecha: 13.06.2024,  Autor: clealz
        /// </remarks>
        public void SetFolderValue(string Folder, bool? Value)
        {
            RegistryKey HKLM;

            HKLM = Environment.Is64BitOperatingSystem
                ? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                : Registry.LocalMachine;

            RegistryKey NameSpace = HKLM.OpenSubKey("SOFTWARE", true)
                .OpenSubKey("Microsoft", true)
                .OpenSubKey("Windows", true)
                .OpenSubKey("CurrentVersion", true)
                .OpenSubKey("Explorer", true)
                .OpenSubKey("MyComputer", true)
                .OpenSubKey("NameSpace", true);

            switch (Folder)
            {
                case "ObjectsTD":
                    {
                        if (Value == true)
                        {
                            if (NameSpace.OpenSubKey("{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}", true) == null)
                                NameSpace.CreateSubKey("{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}", RegistryKeyPermissionCheck.ReadWriteSubTree);
                        }
                        else if (Value == false)
                        {
                            if (NameSpace.OpenSubKey("{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}", true) != null)
                                NameSpace.DeleteSubKey("{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}", throwOnMissingSubKey: false);
                        }
                    }
                    break;
                case "Desktop":
                    {
                        if (Value == true)
                        {
                            if (NameSpace.OpenSubKey("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", true) == null)
                                NameSpace.CreateSubKey("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", RegistryKeyPermissionCheck.ReadWriteSubTree);
                        }
                        else if (Value == false)
                        {
                            if (NameSpace.OpenSubKey("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", true) != null)
                                NameSpace.DeleteSubKey("{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", throwOnMissingSubKey: false);
                        }
                    }
                    break;
                case "Documents":
                    {
                        if (Value == true)
                        {
                            if (NameSpace.OpenSubKey("{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}", true) == null)
                                NameSpace.CreateSubKey("{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}", RegistryKeyPermissionCheck.ReadWriteSubTree);
                            if (NameSpace.OpenSubKey("{d3162b92-9365-467a-956b-92703aca08af}", true) == null)
                                NameSpace.CreateSubKey("{d3162b92-9365-467a-956b-92703aca08af}", RegistryKeyPermissionCheck.ReadWriteSubTree);
                        }
                        else if (Value == false)
                        {
                            if (NameSpace.OpenSubKey("{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}", true) != null)
                                NameSpace.DeleteSubKey("{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}", throwOnMissingSubKey: false);
                            if (NameSpace.OpenSubKey("{d3162b92-9365-467a-956b-92703aca08af}", true) != null)
                                NameSpace.DeleteSubKey("{d3162b92-9365-467a-956b-92703aca08af}", throwOnMissingSubKey: false);
                        }
                    }
                    break;
                case "Downloads":
                    {
                        if (Value == true)
                        {
                            if (NameSpace.OpenSubKey("{374DE290-123F-4565-9164-39C4925E467B}", true) == null)
                                NameSpace.CreateSubKey("{374DE290-123F-4565-9164-39C4925E467B}", RegistryKeyPermissionCheck.ReadWriteSubTree);
                            if (NameSpace.OpenSubKey("{088e3905-0323-4b02-9826-5d99428e115f}", true) == null)
                                NameSpace.CreateSubKey("{088e3905-0323-4b02-9826-5d99428e115f}", RegistryKeyPermissionCheck.ReadWriteSubTree);
                        }
                        else if (Value == false)
                        {
                            if (NameSpace.OpenSubKey("{374DE290-123F-4565-9164-39C4925E467B}", true) != null)
                                NameSpace.DeleteSubKey("{374DE290-123F-4565-9164-39C4925E467B}", throwOnMissingSubKey: false);
                            if (NameSpace.OpenSubKey("{088e3905-0323-4b02-9826-5d99428e115f}", true) != null)
                                NameSpace.DeleteSubKey("{088e3905-0323-4b02-9826-5d99428e115f}", throwOnMissingSubKey: false);
                        }
                    }
                    break;
                case "Pictures":
                    {
                        if (Value == true)
                        {
                            if (NameSpace.OpenSubKey("{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}", true) == null)
                                NameSpace.CreateSubKey("{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}", RegistryKeyPermissionCheck.ReadWriteSubTree);
                            if (NameSpace.OpenSubKey("{24ad3ad4-a569-4530-98e1-ab02f9417aa8}", true) == null)
                                NameSpace.CreateSubKey("{24ad3ad4-a569-4530-98e1-ab02f9417aa8}", RegistryKeyPermissionCheck.ReadWriteSubTree);
                        }
                        else if (Value == false)
                        {
                            if (NameSpace.OpenSubKey("{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}", true) != null)
                                NameSpace.DeleteSubKey("{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}", throwOnMissingSubKey: false);
                            if (NameSpace.OpenSubKey("{24ad3ad4-a569-4530-98e1-ab02f9417aa8}", true) != null)
                                NameSpace.DeleteSubKey("{24ad3ad4-a569-4530-98e1-ab02f9417aa8}", throwOnMissingSubKey: false);
                        }
                    }
                    break;
                case "Music":
                    {
                        if (Value == true)
                        {
                            if (NameSpace.OpenSubKey("{1CF1260C-4DD0-4ebb-811F-33C572699FDE}", true) == null)
                                NameSpace.CreateSubKey("{1CF1260C-4DD0-4ebb-811F-33C572699FDE}", RegistryKeyPermissionCheck.ReadWriteSubTree);
                            if (NameSpace.OpenSubKey("{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}", true) == null)
                                NameSpace.CreateSubKey("{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}", RegistryKeyPermissionCheck.ReadWriteSubTree);
                        }
                        else if (Value == false)
                        {
                            if (NameSpace.OpenSubKey("{1CF1260C-4DD0-4ebb-811F-33C572699FDE}", true) != null)
                                NameSpace.DeleteSubKey("{1CF1260C-4DD0-4ebb-811F-33C572699FDE}", throwOnMissingSubKey: false);
                            if (NameSpace.OpenSubKey("{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}", true) != null)
                                NameSpace.DeleteSubKey("{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}", throwOnMissingSubKey: false);
                        }
                    }
                    break;
                case "Videos":
                    {
                        if (Value == true)
                        {
                            if (NameSpace.OpenSubKey("{A0953C92-50DC-43bf-BE83-3742FED03C9C}", true) == null)
                                NameSpace.CreateSubKey("{A0953C92-50DC-43bf-BE83-3742FED03C9C}", RegistryKeyPermissionCheck.ReadWriteSubTree);
                            if (NameSpace.OpenSubKey("{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}", true) == null)
                                NameSpace.CreateSubKey("{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}", RegistryKeyPermissionCheck.ReadWriteSubTree);
                        }
                        else if (Value == false)
                        {
                            if (NameSpace.OpenSubKey("{A0953C92-50DC-43bf-BE83-3742FED03C9C}", true) != null)
                                NameSpace.DeleteSubKey("{A0953C92-50DC-43bf-BE83-3742FED03C9C}", throwOnMissingSubKey: false);
                            if (NameSpace.OpenSubKey("{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}", true) != null)
                                NameSpace.DeleteSubKey("{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}", throwOnMissingSubKey: false);
                        }
                    }
                    break;
            }
        }
    }
}

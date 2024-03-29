﻿using System;
using Raven.Client.FileSystem;

namespace DemoMethods
{
    public static class FileStoreHolder
    {
        private static readonly Lazy<IFilesStore> FsStore = new Lazy<IFilesStore>(CreateStore);

        public static IFilesStore FilesSystemStore
        {
            get { return FsStore.Value; }
        }

        private static IFilesStore CreateStore()
        {
            var filesStore = new FilesStore()
            {
                Url = String.Format("http://{0}:{1}", DocumentStoreHolder.Address, DocumentStoreHolder.Port),
                DefaultFileSystem = DocumentStoreHolder.DatabaseName + "FS"
            }.Initialize();

            return filesStore;
        }
    }
}

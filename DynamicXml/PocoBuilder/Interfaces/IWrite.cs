﻿using System.IO;
using System.Threading.Tasks;

namespace DynamicXml
{
    public interface IWrite
    {
        void FromFile(string filePath);

        Task FromFileAsync(string filePath);

        void FromStream(Stream stream);

        Task FromStreamAsync(Stream stream);
    }
}
﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Parsely
{
    public static class EmbeddedResources
    {
        public static StreamReader GetStreamReader(this Assembly assembly, string name)
        {
            try
            {
                foreach (string resourceName in assembly.GetManifestResourceNames() ?? Enumerable.Empty<string>())
                {
                    if (resourceName.EndsWith(name))
                    {
                        return new StreamReader(assembly.GetManifestResourceStream(resourceName));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("{0}: {1}", MethodBase.GetCurrentMethod().Name, ex.ToString()));
            }

            return null;
        }

        public static string GetEmbeddedContent(this Assembly assembly, string name)
        {
            try
            {
                StreamReader reader = assembly.GetStreamReader(name);

                if (reader == null)
                {
                    return string.Empty;
                }

                string data = reader.ReadToEnd();
                reader.Close();

                return data;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("ლ(ಠ益ಠლ) {0}: {1}", MethodBase.GetCurrentMethod().Name, ex.ToString()));
            }

            return string.Empty;
        }

        public static string GetEmbeddedContent(string name)
        {
            return GetEmbeddedContent(typeof(EmbeddedResources).Assembly, name);
        }
    }
}

﻿using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnhancedVerification.Shared.LogService
{
    public class LogWritter : ILogWritter
    {
        private readonly IHostEnvironment env;

        private string m_exePath = string.Empty;

        public LogWritter(IHostEnvironment env)
        {
            this.env = env;

        }
        public string LogWarn(string logMessage, string type)
        {
            try
            {
                Directory.CreateDirectory(env.ContentRootPath + "/Log/" + type.ToString() + "/");
                m_exePath = env.ContentRootPath + "/Log/" + type.ToString() + "/" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
                if (!File.Exists(m_exePath))
                {
                    using (StreamWriter sw = File.CreateText(m_exePath))
                    {
                        Log(logMessage, sw);
                    }
                }
                else
                {
                    using (StreamWriter w = File.AppendText(m_exePath))
                    {
                        Log(logMessage, w);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string LogWrite(string logMessage, string type)
        {
            try
            {
                Directory.CreateDirectory(env.ContentRootPath + "/Log/" + type.ToString() + "/");
                m_exePath = env.ContentRootPath + "/Log/" + type.ToString() + "/" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
                if (!File.Exists(m_exePath))
                {
                    using (StreamWriter sw = File.CreateText(m_exePath))
                    {
                        Log(logMessage, sw);
                    }
                }
                else
                {
                    using (StreamWriter w = File.AppendText(m_exePath))
                    {
                        Log(logMessage, w);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0}", DateTime.Now.ToLongTimeString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

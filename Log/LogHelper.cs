using System;

using log4net;

namespace Tup.Utilities
{
    /// <summary>
    /// ��־���� ����
    /// Log4net����-Log4netʹ�÷�װ��
    /// </summary>
    /// <remarks>
    /// http://zhq.ahau.edu.cn/blog/article.asp?id=366
    /// </remarks>
    public static class LogHelper
    {
        private const string LOG_REPOSITORY = "Default"; // this should likely be set in the web config.
        private readonly static ILog m_log = log4net.LogManager.GetLogger(typeof(object));

        /// <summary>
        /// ��ʼ����־ϵͳ
        /// ��ϵͳ���п�ʼ��ʼ��
        /// Global.asax Application_Start��
        /// </summary>
        public static void Init()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// д����־
        /// </summary>
        /// <param name="message">��־��Ϣ</param>
        /// <param name="messageType">��־����</param>
        public static void Write(string message, LogMessageType messageType)
        {
            DoLog(message, messageType, null, Type.GetType("System.Object"));
        }

        /// <summary>
        /// д����־
        /// </summary>
        /// <param name="message">��־��Ϣ</param>
        /// <param name="messageType">��־����</param>
        /// <param name="type"></param>
        public static void Write(string message, LogMessageType messageType, Type type)
        {
            DoLog(message, messageType, null, type);
        }

        /// <summary>
        /// д����־
        /// </summary>
        /// <param name="message">��־��Ϣ</param>
        /// <param name="messageType">��־����</param>
        /// <param name="ex">�쳣</param>
        public static void Write(string message, LogMessageType messageType, Exception ex)
        {
            DoLog(message, messageType, ex, Type.GetType("System.Object"));
        }

        /// <summary>
        /// д����־
        /// </summary>
        /// <param name="message">��־��Ϣ</param>
        /// <param name="messageType">��־����</param>
        /// <param name="ex">�쳣</param>
        /// <param name="type"></param>
        public static void Write(string message, LogMessageType messageType, Exception ex,
                                 Type type)
        {
            DoLog(message, messageType, ex, type);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="condition">����</param>
        /// <param name="message">��־��Ϣ</param>
        public static void Assert(bool condition, string message)
        {
            Assert(condition, message, Type.GetType("System.Object"));
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="condition">����</param>
        /// <param name="message">��־��Ϣ</param>
        /// <param name="type">��־����</param>
        public static void Assert(bool condition, string message, Type type)
        {
            if (condition == false)
                Write(message, LogMessageType.Info);
        }

        /// <summary>
        /// ������־
        /// </summary>
        /// <param name="message">��־��Ϣ</param>
        /// <param name="messageType">��־����</param>
        /// <param name="ex">�쳣</param>
        /// <param name="type">��־����</param>
        private static void DoLog(string message, LogMessageType messageType, Exception ex,
                                  Type type)
        {
            switch (messageType)
            {
                case LogMessageType.Debug:
                    LogHelper.m_log.Debug(message, ex);
                    break;

                case LogMessageType.Info:
                    LogHelper.m_log.Info(message, ex);
                    break;

                case LogMessageType.Warn:
                    LogHelper.m_log.Warn(message, ex);
                    break;

                case LogMessageType.Error:
                    LogHelper.m_log.Error(message, ex);
                    break;

                case LogMessageType.Fatal:
                    LogHelper.m_log.Fatal(message, ex);
                    break;
            }
        }

        /// <summary>
        /// ��־����
        /// </summary>
        public enum LogMessageType
        {
            /// <summary>
            /// ����
            /// </summary>
            Debug,
            /// <summary>
            /// ��Ϣ
            /// </summary>
            Info,
            /// <summary>
            /// ����
            /// </summary>
            Warn,
            /// <summary>
            /// ����
            /// </summary>
            Error,
            /// <summary>
            /// ��������
            /// </summary>
            Fatal
        }
    }
}
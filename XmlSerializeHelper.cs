using System;
using System.IO;
using System.Xml.Serialization;

namespace Tup.Utilities
{
    /// <summary>
    /// XML ���л� ����
    /// </summary>
    public static class XmlSerializeHelper
    {
        #region ��̬����
        /// <summary>
        /// XML ���л�ĳһ���Ͷ���ָ�����ļ�
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        /// <exception cref="ArgumentNullException">filePath arg is null</exception>
        /// <exception cref="ArgumentNullException">obj arg is null</exception>
        public static void SerializeToXml<T>(string filePath, T obj)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("filePath", "filePath arg is null");
            if (obj == null)
                throw new ArgumentNullException("obj", "filePath arg is null");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(writer, obj);
            }
        }
        /// <summary>
        /// ��ĳһ XML �ļ������л���ĳһ���Ͷ���
        /// </summary>
        /// <param name="filePath">�������л��� XML �ļ�����</param>
        /// <param name="type">�����л�����</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">filePath arg is null</exception>
        public static T DeserializeFromXml<T>(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("filePath", "filePath arg is null");
            if (!File.Exists(filePath))
                throw new FileNotFoundException("filePath File not found");

            using (StreamReader reader = new StreamReader(filePath))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(reader);
            }
        }
        #endregion
    }
}

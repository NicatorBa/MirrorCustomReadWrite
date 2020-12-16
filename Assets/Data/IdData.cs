using Mirror;

namespace Data
{
    public readonly struct IdData
    {
        private readonly string _id;

        private IdData(string id)
        {
            _id = id;
        }

        public static IdData Parse(string id)
        {
            return new IdData(id);
        }

        public override string ToString()
        {
            return _id;
        }
    }
    
    public static class IdDataReaderWriter
    {
        public static void WriteIdData(this NetworkWriter writer, IdData data)
        {
            writer.WriteString(data.ToString());
        }
     
        public static IdData ReadIdData(this NetworkReader reader)
        {
            return IdData.Parse(reader.ReadString());
        }
    }
}

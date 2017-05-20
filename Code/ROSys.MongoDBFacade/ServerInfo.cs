namespace ROSys.MongoDBFacade
{
    public class ServerInfo
    {
        public string DbName { get; internal set; }
        public string DbPassword { get; internal set; }
        public int DbPort { get; internal set; }
        public string DbServerIP { get; internal set; }
        public string DbUserName { get; internal set; }
    }
}
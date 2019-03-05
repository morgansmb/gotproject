namespace DataAccessLayer
{
    public class DALManager
    {
        private static DALManager _instance;
        private static readonly object padlock = new object();
        public IDAL DALServer { get; private set; }

        public static DALManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DALManager(new DALSQLServer());
                        }
                    }
                }
                return _instance;
            }
        }

        private DALManager(IDAL DAL)
        {
            DALServer = DAL;
        }
    }
}

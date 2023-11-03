namespace api_flora.Entities.Noticia
{
    public class HipervinculoNoticia
    {
        private long id;
        private string str;

        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Str
        {
            get { return this.str; }
            set { this.str = value; }
        }
    }
}

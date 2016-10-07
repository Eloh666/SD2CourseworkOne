namespace CourseworkOneMetro.Models
{
    public class Instutution
    {
        private string _instututionName;
        private string _instututionAddress;

        public string InstututionTitle
        {
            get { return _instututionName; }
            set { _instututionName = value; }
        }

        public string InstitutionAddress
        {
            get { return _instututionAddress; }
            set { _instututionAddress = value; }
        }
    }
}
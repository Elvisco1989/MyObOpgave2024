namespace ObOpgave2024
{
    public class Beer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Abv { get; set; }


        public override string ToString()
        {
            return $"{ID},{Name},{Abv}"; ;
        }

        public void ValidateAbv()
        {
            if (Abv < 0 || Abv > 67)
            {
                throw new ArgumentException("Abv should  be between 0 and 67");
            }

        }

        public void ValidateName()
        {
            if (Name is null)
            {
                throw new ArgumentNullException("Name should not be null");
            }
            if (Name.Length < 3)
            {
                throw new ArgumentException("Name should be more than three character");
            }

        }

        public void Validate()
        {
            ValidateName();
            ValidateAbv();
        }


    }
}
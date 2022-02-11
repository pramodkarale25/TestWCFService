using System.Runtime.Serialization;

namespace TestWCFService
{
	[DataContract]
    public class SuperHero
    {
		[DataMember]
        public int Id { get; set; }
		[DataMember]
		public string FirstName { get; set; }
		[DataMember]
		public string LastName { get; set; }
		[DataMember]
		public string HeroName { get; set; }
		[DataMember]
		public string PlaceOfBirth { get; set; }
		[DataMember]
		public int Combat { get; set; }
    }
}

namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
		const int maxPageSize = 50;
		//Auto-implemented prop
        public int PageNumber { get; set; }
		private int _pageSize;

		//full-prop
		public int PageSize
		{
			get { return _pageSize; }
			set { _pageSize = value > maxPageSize ? maxPageSize : value; }
		}

		public String? OrderBy { get; set; }

        public String? Fields { get; set; }
    }
}

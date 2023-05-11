namespace MvcApp.Models
{
    public class IndexViewModel
    {
        //старрый код
        //public IEnumerable<User> Users { get; set; } = new List<User>();
        //public SortViewModel SortViewModel { get; set; } = new SortViewModel(SortState.NameAsc);


        //старрый код
        //public IEnumerable<User> Users { get; }
        //public PageViewModel PageViewModel { get; }
        //public IndexViewModel(IEnumerable<User> users, PageViewModel viewModel)
        //{
        //    Users = users;
        //    PageViewModel = viewModel;
        //}


        public IEnumerable<User> Users { get; }
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public SortViewModel SortViewModel { get; }
        public IndexViewModel(IEnumerable<User> users, PageViewModel pageViewModel,
            FilterViewModel filterViewModel, SortViewModel sortViewModel)
        {
            Users = users;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
            SortViewModel = sortViewModel;
        }
    }
}
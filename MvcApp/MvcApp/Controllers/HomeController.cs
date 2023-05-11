using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        //Задание№2
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //Задание№3
        //[HttpGet]
        //public async Task Index()
        //{
        //    string content = @"<form method='post'>
        //        <label>Name:</label><br />
        //        <input name='name' /><br />
        //        <label>Age:</label><br />
        //        <input type='number' name='age' /><br />
        //        <input type='submit' value='Send' />
        //    </form>";
        //    Response.ContentType = "text/html;charset=utf-8";
        //    await Response.WriteAsync(content);

        //}
        //[HttpPost]
        //public string Index(string name, int age) => $"{name}: {age}";

        //Задание№4
        //[HttpGet]
        //public IActionResult Index() => View();
        //[HttpPost]
        //public string Index(string username, string password, int age, string comment)
        //{
        //    return $"User Name: {username}   Password: {password}   Age: {age}  Comment: {comment}";
        //}

        //Задание№5
        //List<Person> people = new List<Person>
        //{
        //    new Person(1, "Tom", 37),
        //    new Person(2, "Bob", 41),
        //    new Person(3, "Sam", 28)
        //};
        //public IActionResult Index()
        //{
        //    return View(people);
        //}

        //Задание№6 БД
        //ApplicationContext db;
        //public HomeController(ApplicationContext context)
        //{
        //    db = context;
        //}
        //public async Task<IActionResult> Index()
        //{
        //    return View(await db.Users.ToListAsync());
        //}
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(User user)
        //{
        //    db.Users.Add(user);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
        //[HttpPost]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id != null)
        //    {
        //        User user = new User { Id = id.Value };
        //        db.Entry(user).State = EntityState.Deleted;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return NotFound();
        //}
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id != null)
        //    {
        //        User? user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
        //        if (user != null) return View(user);
        //    }
        //    return NotFound();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(User user)
        //{
        //    db.Users.Update(user);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //старый код
        //UsersContext db;
        //public HomeController(UsersContext context)
        //{
        //    db = context;
        //    // добавим начальные данные для тестирования
        //    if (!db.Companies.Any())
        //    {
        //        Company oracle = new Company { Name = "Oracle" };
        //        Company google = new Company { Name = "Google" };
        //        Company microsoft = new Company { Name = "Microsoft" };
        //        Company apple = new Company { Name = "Apple" };

        //        User user1 = new User { Name = "Олег Васильев", Company = oracle, Age = 26 };
        //        User user2 = new User { Name = "Александр Овсов", Company = oracle, Age = 24 };
        //        User user3 = new User { Name = "Алексей Петров", Company = microsoft, Age = 25 };
        //        User user4 = new User { Name = "Иван Иванов", Company = microsoft, Age = 26 };
        //        User user5 = new User { Name = "Петр Андреев", Company = microsoft, Age = 23 };
        //        User user6 = new User { Name = "Василий Иванов", Company = google, Age = 23 };
        //        User user7 = new User { Name = "Олег Кузнецов", Company = google, Age = 25 };
        //        User user8 = new User { Name = "Андрей Петров", Company = apple, Age = 24 };

        //        db.Companies.AddRange(oracle, microsoft, google, apple);
        //        db.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8);
        //        db.SaveChanges();
        //    }
        //}
        //public async Task<IActionResult> Index(SortState sortOrder = SortState.NameAsc)
        //{
        //    IQueryable<User> users = db.Users.Include(x => x.Company);

        //    users = sortOrder switch
        //    {
        //        SortState.NameDesc => users.OrderByDescending(s => s.Name),
        //        SortState.AgeAsc => users.OrderBy(s => s.Age),
        //        SortState.AgeDesc => users.OrderByDescending(s => s.Age),
        //        SortState.CompanyAsc => users.OrderBy(s => s.Company!.Name),
        //        SortState.CompanyDesc => users.OrderByDescending(s => s.Company!.Name),
        //        _ => users.OrderBy(s => s.Name),
        //    };
        //    IndexViewModel viewModel = new IndexViewModel
        //    {
        //        Users = await users.AsNoTracking().ToListAsync(),
        //        SortViewModel = new SortViewModel(sortOrder)
        //    };
        //    return View(viewModel);


        //старый код
        //UsersContext db;
        //public HomeController(UsersContext context)
        //{
        //    db = context;
        //    // добавляем начальные данные при их отсутствии
        //    if (!db.Companies.Any())
        //    {
        //        Company oracle = new Company { Name = "Oracle" };
        //        Company google = new Company { Name = "Google" };
        //        Company microsoft = new Company { Name = "Microsoft" };
        //        Company apple = new Company { Name = "Apple" };

        //        User user1 = new User { Name = "Олег Васильев", Company = oracle, Age = 26 };
        //        User user2 = new User { Name = "Александр Овсов", Company = oracle, Age = 24 };
        //        User user3 = new User { Name = "Алексей Петров", Company = microsoft, Age = 25 };
        //        User user4 = new User { Name = "Иван Иванов", Company = microsoft, Age = 26 };
        //        User user5 = new User { Name = "Петр Андреев", Company = microsoft, Age = 23 };
        //        User user6 = new User { Name = "Василий Иванов", Company = google, Age = 23 };
        //        User user7 = new User { Name = "Олег Кузнецов", Company = google, Age = 25 };
        //        User user8 = new User { Name = "Андрей Петров", Company = apple, Age = 24 };

        //        db.Companies.AddRange(oracle, microsoft, google, apple);
        //        db.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8);
        //        db.SaveChanges();
        //    }
        //}
        //public ActionResult Index(int? company, string? name)
        //{
        //    IQueryable<User> users = db.Users.Include(p => p.Company);
        //    if (company != null && company != 0)
        //    {
        //        users = users.Where(p => p.CompanyId == company);
        //    }
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        users = users.Where(p => p.Name!.Contains(name));
        //    }

        //    List<Company> companies = db.Companies.ToList();
        //    // устанавливаем начальный элемент, который позволит выбрать всех
        //    companies.Insert(0, new Company { Name = "Все", Id = 0 });

        //    UserListViewModel viewModel = new UserListViewModel
        //    {
        //        Users = users.ToList(),
        //        Companies = new SelectList(companies, "Id", "Name", company),
        //        Name = name
        //    };
        //    return View(viewModel);
        //}


        //старый код
        //UsersContext db;
        //public HomeController(UsersContext context)
        //{
        //    db = context;
        //    // добавляем начальные данные
        //    if (!db.Companies.Any())
        //    {
        //        Company oracle = new Company { Name = "Oracle" };
        //        Company google = new Company { Name = "Google" };
        //        Company microsoft = new Company { Name = "Microsoft" };
        //        Company apple = new Company { Name = "Apple" };

        //        User user1 = new User { Name = "Олег Васильев", Company = oracle, Age = 26 };
        //        User user2 = new User { Name = "Александр Овсов", Company = oracle, Age = 24 };
        //        User user3 = new User { Name = "Алексей Петров", Company = microsoft, Age = 25 };
        //        User user4 = new User { Name = "Иван Иванов", Company = microsoft, Age = 26 };
        //        User user5 = new User { Name = "Петр Андреев", Company = microsoft, Age = 23 };
        //        User user6 = new User { Name = "Василий Иванов", Company = google, Age = 23 };
        //        User user7 = new User { Name = "Олег Кузнецов", Company = google, Age = 25 };
        //        User user8 = new User { Name = "Андрей Петров", Company = apple, Age = 24 };

        //        db.Companies.AddRange(oracle, microsoft, google, apple);
        //        db.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8);
        //        db.SaveChanges();
        //    }
        //}
        //public async Task<IActionResult> Index(int page = 1)
        //{
        //    int pageSize = 3;   // количество элементов на странице

        //    IQueryable<User> source = db.Users.Include(x => x.Company);
        //    var count = await source.CountAsync();
        //    var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        //    PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
        //    IndexViewModel viewModel = new IndexViewModel(items, pageViewModel);
        //    return View(viewModel);
        //}


        UsersContext db;
        public HomeController(UsersContext context)
        {
            db = context;
            // добавляем начальные данные
            if (!db.Companies.Any())
            {
                Company oracle = new Company { Name = "Oracle" };
                Company google = new Company { Name = "Google" };
                Company microsoft = new Company { Name = "Microsoft" };
                Company apple = new Company { Name = "Apple" };

                User user1 = new User { Name = "Олег Васильев", Company = oracle, Age = 26 };
                User user2 = new User { Name = "Александр Овсов", Company = oracle, Age = 24 };
                User user3 = new User { Name = "Алексей Петров", Company = microsoft, Age = 25 };
                User user4 = new User { Name = "Иван Иванов", Company = microsoft, Age = 26 };
                User user5 = new User { Name = "Петр Андреев", Company = microsoft, Age = 23 };
                User user6 = new User { Name = "Василий Иванов", Company = google, Age = 23 };
                User user7 = new User { Name = "Олег Кузнецов", Company = google, Age = 25 };
                User user8 = new User { Name = "Андрей Петров", Company = apple, Age = 24 };

                db.Companies.AddRange(oracle, microsoft, google, apple);
                db.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8);
                db.SaveChanges();
            }
        }
        public async Task<IActionResult> Index(string name, int company = 0, int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;

            //фильтрация
            IQueryable<User> users = db.Users.Include(x => x.Company);

            if (company != 0)
            {
                users = users.Where(p => p.CompanyId == company);
            }
            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name!.Contains(name));
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    users = users.OrderByDescending(s => s.Name);
                    break;
                case SortState.AgeAsc:
                    users = users.OrderBy(s => s.Age);
                    break;
                case SortState.AgeDesc:
                    users = users.OrderByDescending(s => s.Age);
                    break;
                case SortState.CompanyAsc:
                    users = users.OrderBy(s => s.Company!.Name);
                    break;
                case SortState.CompanyDesc:
                    users = users.OrderByDescending(s => s.Company!.Name);
                    break;
                default:
                    users = users.OrderBy(s => s.Name);
                    break;
            }

            // пагинация
            var count = await users.CountAsync();
            var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(db.Companies.ToList(), company, name),
                new SortViewModel(sortOrder)
            );
            return View(viewModel);
        }
    }
}

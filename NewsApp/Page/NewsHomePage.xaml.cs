using NewsApp.models;
using NewsApp.Services;

namespace NewsApp.Page;

public partial class NewsHomePage : ContentPage
{
	public List<Article> ArticlesList;
    public List<Category> CategoryList = new List<Category>()
    {
        new Category(){Name="World", ImageUrl = "world.png"},
        new Category(){Name = "Nation" , ImageUrl="nation.png"},
        new Category(){Name = "Business" , ImageUrl="business.png"},
        new Category(){Name = "Technology" , ImageUrl="technology.png"},
        new Category(){Name = "Entertainment", ImageUrl = "entertainment.png"},
        new Category(){Name = "Sports" , ImageUrl="sports.png"},
        new Category(){Name = "Science", ImageUrl= "science.png"},
        new Category(){Name = "Health", ImageUrl="health.png"},
    };
    public NewsHomePage()
	{
		InitializeComponent();
		GetBreakingNew();
		ArticlesList = new List<Article>();
        CvCategories.ItemsSource = CategoryList;
	}

    private async void GetBreakingNew()
    {
        var apiService = new ApiService();
        var newsResult = await apiService.GetNews("general");
        foreach (var item in newsResult.Articles)
        {
            ArticlesList.Add(item);
        }
        CvNews.ItemsSource = ArticlesList;
    }

    private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedltem = e.CurrentSelection.FirstOrDefault()as Category;
        if (selectedltem == null) return;
        Navigation.PushAsync(new NewListPage(selectedltem.Name));
        ((CollectionView)sender).SelectedItem = null;
    }
}
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using ProjetoAecTeste.Services.Interfaces;
using ProjetoAecTeste.Models.CursoModelDTO;

public class CursoAplication
{
    private readonly ICursoService _cursoService;
    private readonly IWebDriver _driver;
  

    public CursoAplication(ICursoService cursoService, IWebDriver driver)
    {
        _cursoService = cursoService;
        _driver = driver;
    }

    public async Task BuscarCursos()
    {

        try {
        string mensagem = "";

       
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

            _driver.Navigate().GoToUrl("https://www.alura.com.br");
            _driver.Manage().Window.Maximize();

            mensagem = "Automação AeC";
            Console.WriteLine(mensagem);

            // Preencher o campo de pesquisa
            await Task.Delay(2000);
            var campoPesquisa = _driver.FindElement(By.Id("header-barraBusca-form-campoBusca"));
            campoPesquisa.Click();
            campoPesquisa.Clear();
            campoPesquisa.SendKeys("Curso Programação C#");
            await Task.Delay(2000);

            // Clicar no botão buscar
            _driver.FindElement(By.CssSelector("body > main > section.home__header > header > div > nav > div.header__nav--busca.header-barraBusca > form > button > svg")).Click();

            await Task.Delay(2000);
            // Clicar no Curso: Curso Avançando com C++: performance e otimização
            _driver.FindElement(By.CssSelector("#busca-resultados > ul > li:nth-child(1) > a > div > h4")).Click();

            //Scroll
            IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;
            jse.ExecuteScript("scrollBy(0,1490)", "");
            await Task.Delay(2000);

            // Realizar a busca e gravar os resultados no banco de dados
            var Titulo = _driver.FindElement(By.CssSelector("body > section.course-header__wrapper > div > div.course-icon-title-flex > h1")).Text.ToString();
            var Professor = _driver.FindElement(By.CssSelector("#section-icon > div.course-container--instructor > section > div > div > div > h3")).Text.ToString();
            var CargaHoraria = _driver.FindElement(By.CssSelector("body > section.course-header__wrapper > div > div.course-container-flex--desktop > div.course-container__co-branded_icon > div > div:nth-child(1) > div > p.courseInfo-card-wrapper-infos")).Text.ToString();
            var Descricao = _driver.FindElement(By.CssSelector("#section-icon > div.course-container--instructor > section > div > p")).Text.ToString();

           var curso = new CursoModelDTO
            {
                Titulo = Titulo,
                Professor = Professor,
                CargaHoraria = CargaHoraria,
                Descricao = Descricao
            };

            await _cursoService.SalvarCursos(curso);

 
        }catch(Exception ex)
        {
            Console.WriteLine($"Erro ao salvar curso: {ex.Message}");

        }
        finally {


            _driver.Quit();
            //Environment.Exit(0);//Fechar a aplicação 

        }
     }
 }
         
   


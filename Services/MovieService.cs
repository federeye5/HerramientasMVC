 using Clase4.Models;

 namespace Clase4.Services;
 public static class MovieService{
    static List<Movie> Movies {get;set;}

    static MovieService(){
        Movies = new List<Movie>{
            new Movie{Name="The Shawshank Redemption",Code="AVT",Minutes= 9,Category="Sci-Fi" },
            new Movie{Name="The Shawshank Redemption",Code="JTR",Minutes= 9,Category="Sci-Fi" },
            new Movie{Name="The Shawshank Redemption",Code="LLL",Minutes= 9,Category="Sci-Fi" },
            new Movie{Name="The Shawshank Redemption",Code="HPT",Minutes= 9,Category="Sci-Fi" },
            new Movie{Name="The Shawshank Redemption",Code="WTF",Minutes= 9,Category="Sci-Fi" },
            new Movie{Name="The Shawshank Redemption",Code="AGF",Minutes= 9,Category="Sci-Fi" },
            new Movie{Name="The Shawshank Redemption",Code="RTP",Minutes= 9,Category="Sci-Fi" },
            new Movie{Name="The Shawshank Redemption",Code="ATP",Minutes= 9,Category="Sci-Fi" },
            new Movie{Name="The Shawshank Redemption",Code="GIL",Minutes= 9,Category="Sci-Fi" },
            new Movie{Name="The Shawshank Redemption",Code="PAT",Minutes= 9,Category="Sci-Fi" }
        };

    }
    
    public static List<Movie> GetAll() => Movies;

    public static void Add(Movie movie){
        Movies.Add (movie);
    }

    public static void Delete(string code){
        var movieDelete = Get(code);
        if(movieDelete != null){
            Movies.Remove(movieDelete);
        }
        
    }

    public static Movie Get(string code) => Movies.FirstOrDefault(x => x.Code.ToLower() == code.ToLower()); //usa lambda para buscar la primera que salga con el mismo codigo que le mandemos a la funcion

 }
    
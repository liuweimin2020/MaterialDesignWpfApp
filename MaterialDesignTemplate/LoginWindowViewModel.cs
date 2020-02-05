using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace MaterialDesignTemplate
{


    public class LoginWindowViewModel 
    {
        private object _selectedItem;

        public ObservableCollection<MovieCategory> MovieCategories { get; }

        public AnotherCommandImplementation AddCommand { get; }

        public AnotherCommandImplementation RemoveSelectedItemCommand { get; }

        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                this.MutateVerbose(ref _selectedItem, value, args => PropertyChanged?.Invoke(this, args));
            }
        }

        public LoginWindowViewModel()
        {
            MovieCategories = new ObservableCollection<MovieCategory>
            {
                new MovieCategory("Action",
                    new Movie ("Predator", "John McTiernan"),
                    new Movie("Alien", "Ridley Scott"),
                    new Movie("Prometheus", "Ridley Scott")),
                new MovieCategory("Comedy",
                    new Movie("EuroTrip", "Jeff Schaffer"),
                    new Movie("EuroTrip", "Jeff Schaffer")
                )
            };

            AddCommand = new AnotherCommandImplementation(
                _ =>
                {
                    if (!MovieCategories.Any())
                    {
                        MovieCategories.Add(new MovieCategory(GenerateString(15)));
                    }
                    else
                    {
                        var index = new Random().Next(0, MovieCategories.Count);

                        MovieCategories[index].Movies.Add(
                            new Movie(GenerateString(15), GenerateString(20)));
                    }
                });

            RemoveSelectedItemCommand = new AnotherCommandImplementation(
                _ =>
                {
                    var movieCategory = SelectedItem as MovieCategory;
                    if (movieCategory != null)
                    {
                        MovieCategories.Remove(movieCategory);
                    }
                    else
                    {
                        var movie = SelectedItem as Movie;
                        if (movie == null) return;
                        MovieCategories.FirstOrDefault(v => v.Movies.Contains(movie))?.Movies.Remove(movie);
                    }
                },
                _ => SelectedItem != null);
        }

        private static string GenerateString(int length)
        {
            var random = new Random();

            return string.Join(string.Empty,
                Enumerable.Range(0, length)
                .Select(v => (char)random.Next('a', 'z' + 1)));
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void MutateVerbose<TField>(ref TField field, TField newValue, Action<PropertyChangedEventArgs> raise, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<TField>.Default.Equals(field, newValue)) return;
            field = newValue;
            raise?.Invoke(new PropertyChangedEventArgs(propertyName));
        }

    }


}

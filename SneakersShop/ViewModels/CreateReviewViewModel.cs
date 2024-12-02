using SneakersShop.Common;
using SneakersShop.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.ViewModels
{
    public class CreateReviewViewModel : BaseViewModel
    {
        private Prop<string> text = new Prop<string>();
        private Prop<string> characterCount = new Prop<string>();
        private int selectedRating;

        public Command<int> SetRatingCommand { get; }
        public ObservableCollection<StarModel> Stars { get; set; } = new ObservableCollection<StarModel>();
        public CreateReviewViewModel()
        {
            Text.OnValueChange = Validate;

            Text.Error = "";
            InitializeStars();

            SetRatingCommand = new Command<int>(SetRating);
            CharacterCount.Value = "0/150";
        }

        public Prop<string> Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged();
                UpdateCharacterCount(); // Ažuriraj broj karaktera kada se tekst menja
            }
        }

        public Prop<string> CharacterCount
        {
            get => characterCount;
            set
            {
                characterCount = value;
                OnPropertyChanged();
            }
        }
        public int SelectedRating
        {
            get => selectedRating;
            set
            {
                selectedRating = value;
                OnPropertyChanged();
                UpdateStars(value); // Ažuriraj zvezdice kada se promeni ocena
            }
        }

        private void UpdateCharacterCount()
        {
            int currentLength = Text.Value.Length;
            CharacterCount.Value = $"{currentLength}/150"; // Formatiraj string kao "trenutni broj/ukupno"
        }

        private void SetRating(int index)
        {
            SelectedRating = index;  // Postavljanje selektovane ocene

            // Ažuriraj status svake zvezdice
            for (int i = 0; i < Stars.Count; i++)
            {
                Stars[i].IsFilled = i < index; // Postavi popunjene zvezdice do odabrane ocene
            }
            // Osveži UI
            OnPropertyChanged(nameof(Stars));
        }

        private void InitializeStars()
        {
            Stars = new ObservableCollection<StarModel>
            {
                new StarModel { Index = 1, IsFilled = false },
                new StarModel { Index = 2, IsFilled = false },
                new StarModel { Index = 3, IsFilled = false },
                new StarModel { Index = 4, IsFilled = false },
                new StarModel { Index = 5, IsFilled = false },
            };
        }

        private void UpdateStars(int rating)
        {
            for (int i = 0; i < Stars.Count; i++)
            {
                Stars[i].IsFilled = i < rating; // Postavi popunjene zvezdice do odabrane ocene
            }
        }

        private void Validate()
        {
            var validator = new CreateReviewViewModelValidator();

            var result = validator.Validate(this);

            if (!result.IsValid)
            {

                var textError = result.Errors.FirstOrDefault(x => x.PropertyName.Contains("Text"));
                if (textError != null)
                {
                    Text.Error = textError.ErrorMessage;
                }
                else
                {
                    Text.Error = "";
                }
            }
            else
            {
                Text.Error = "";
            }
        }
    }

    public class StarModel : BaseViewModel
    {
        public int Index { get; set; } // Indeks zvezdice

        private bool isFilled;
        public bool IsFilled
        {
            get => isFilled;
            set
            {
                isFilled = value;
                OnPropertyChanged();
            }
        }
    }
}

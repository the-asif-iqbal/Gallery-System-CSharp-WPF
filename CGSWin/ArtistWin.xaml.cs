using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using CGSLibrary;

namespace CGSWin
{
    /// <summary>
    /// Interaction logic for ArtistWin.xaml
    /// </summary>
    public partial class ArtistWin : Window
    {
        Gallery gal = new Gallery();
        public ArtistWin()
        {
            InitializeComponent();
        }
        private void addArtists_Click(object sender, RoutedEventArgs e)
        {
            string artistID = ID.Text;
            string fname = artistFirstName.Text;
            string lname = artistLastName.Text;
            if (artistID != "" && fname != "" && lname != "")
            {
                if (artistFirstName.Text.Length <= 20 && artistFirstName.Text.Length > 2)
                {
                    if (artistLastName.Text.Length <= 20 && artistLastName.Text.Length > 2)
                    {
                        if (!(artistFirstName.Text.Any(char.IsDigit)))
                        {
                            if (!(artistLastName.Text.Any(char.IsDigit)))
                            {
                                if (new Regex(@"^([A]{1}\d{4})?$").IsMatch(ID.Text))
                                {
                                    gal.AddArtist(fname, lname, artistID);
                                    MessageBox.Show("Artist Added Successfully!", "Success");
                                    ID.Clear();
                                    artistFirstName.Clear();
                                    artistLastName.Clear();
                                    ID.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid ArtistID - should follow format - A####", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    ID.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Last Name - should not contain digits", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                artistLastName.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid First Name - should not contain digits", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            artistFirstName.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Last Name - should be between 3-20 characters", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        artistLastName.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid First Name - should be between 3-20 characters", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    artistFirstName.Focus();
                }
            }
            else
            {
                MessageBox.Show("Fields cannot be left blank", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                ID.Clear();
                artistFirstName.Clear();
                artistLastName.Clear();
                ID.Focus();
            }

        }
        private void listArtists_Click(object sender, RoutedEventArgs e)
        {
            //listArtist.Text = "Name\t" + "ID\n";
            listArtist.Clear();
            foreach (Artist artist in Gallery.artists)
            {
                listArtist.Text += artist.ToString();
            }
        }
        private void mainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu();
            this.Close();
            mm.ShowDialog();
        }
    }
}

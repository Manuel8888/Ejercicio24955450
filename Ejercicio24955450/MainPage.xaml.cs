namespace Ejercicio24955450
{
    public partial class MainPage : ContentPage
    {
        int _editNumeroId = 0;
        private readonly LocalDbService _dbService = new LocalDbService();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            int valor = int.Parse(valorEntryField.Text);

            if (_editNumeroId == 0)
            {
                await _dbService.Create(new Numero
                {
                    Valor = valor
                });
            }
            else
            {
                await _dbService.Update(new Numero
                {
                    Id = _editNumeroId,
                    Valor = valor
                });
                _editNumeroId = 0;
            }

            valorEntryField.Text = string.Empty;

            ListView.ItemsSource = await _dbService.GetNumeros();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var numero = (Numero)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");
            switch (action)
            {
                case "Edit":
                    _editNumeroId = numero.Id;
                    valorEntryField.Text = numero.Valor.ToString();
                    break;

                case "Delete":
                    await _dbService.Delete(numero);
                    ListView.ItemsSource = await _dbService.GetNumeros();
                    break;
            }
        }
    }
}



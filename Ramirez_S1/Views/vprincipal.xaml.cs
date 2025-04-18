using System.Text.RegularExpressions;

namespace Ramirez_S1.Views;

public partial class vprincipal : ContentPage
{
	public vprincipal()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string numeroId = txtNumeroIdentificacion.Text?.Trim();
        string apellidoPaterno = txtApellidoPaterno.Text?.Trim();
        string apellidoMaterno = txtApellidoMaterno.Text?.Trim();
        string nombres = txtNombresCompletos.Text?.Trim();
        string telefono = txtTelefono.Text?.Trim();
        string correo = txtCorreo.Text?.Trim();
        string confirmarCorreo = txtConfirmarCorreo.Text?.Trim();



        if (!Regex.IsMatch(numeroId, @"^\d+$"))
        {
            await DisplayAlert("Error", "El n˙mero de identificaciÛn debe contener solo n˙meros.", "OK");
            return;
        }

        if (!Regex.IsMatch(telefono, @"^\d+$"))
        {
            await DisplayAlert("Error", "El telÈfono debe contener solo n˙meros.", "OK");
            return;
        }

        if (!Regex.IsMatch(apellidoPaterno, @"^[a-zA-Z·ÈÌÛ˙¡…Õ”⁄Ò—\s]+$"))
        {
            await DisplayAlert("Error", "El apellido paterno debe contener solo letras.", "OK");
            return;
        }

        if (!Regex.IsMatch(apellidoMaterno, @"^[a-zA-Z·ÈÌÛ˙¡…Õ”⁄Ò—\s]*$"))
        {
            await DisplayAlert("Error", "El apellido materno debe contener solo letras.", "OK");
            return;
        }

        if (!Regex.IsMatch(nombres, @"^[a-zA-Z·ÈÌÛ˙¡…Õ”⁄Ò—\s]+$"))
        {
            await DisplayAlert("Error", "Los nombres deben contener solo letras.", "OK");
            return;
        }


        if (!correo.Equals(confirmarCorreo, StringComparison.OrdinalIgnoreCase))
        {
            await DisplayAlert("Error", "Los correos no coinciden.", "OK");
            return;
        }

        string contenido = $"IdentificaciÛn:  {numeroId}\n" +
                           $"Apellidos: {apellidoPaterno} {apellidoMaterno}\n" +
                           $"Nombres: {nombres}\n" +
                           $"TelÈfono: {telefono}\n" +
                           $"Correo: {correo}";


        string fileName = Path.Combine(FileSystem.AppDataDirectory, "inscripcion.txt");
        File.WriteAllText(fileName, contenido);

        await DisplayAlert("…xito", "Datos guardados correctamente.", "OK");
    }


}
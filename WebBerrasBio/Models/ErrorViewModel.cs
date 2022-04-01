namespace WebBerrasBio.Models;

 /// <summary>
 /// En fel-hanterings model. Skapad av visual studio.
 /// </summary>
public class ErrorViewModel
{
    public string? RequestId { get; set; }
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

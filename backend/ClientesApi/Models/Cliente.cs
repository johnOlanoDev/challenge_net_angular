using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("CLIENTES")]
public class Cliente
{
    [Column("ID")]
    public int Id { get; set; }

    [Column("RUC")]
    [MaxLength(20)]
    public string Ruc { get; set; }

    [Column("RAZON_SOCIAL")]
    [MaxLength(250)]
    public string RazonSocial { get; set; }

    [Column("TELEFONO")]
    [MaxLength(30)]
    public string Telefono { get; set; }

    [Column("CORREO")]
    [MaxLength(250)]
    public string Correo { get; set; }

    [Column("DIRECCION")]
    public string Direccion { get; set; }
}
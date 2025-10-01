using OfficeOpenXml;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LectorDeReportesPri
{
    public partial class Principal : Form
    {
        private DataTable tablaDeDatos;

        public Principal()
        {
            InitializeComponent();
            dgvReporte.AutoGenerateColumns = false;
            ExcelPackage.License.SetNonCommercialPersonal("ALEX");
            ConfigurarEstadoInicial();
        }

        private void ConfigurarEstadoInicial()
        {
            cmbEstado.Enabled = false;
            cmbMunicipio.Enabled = false;
            btnReset.Enabled = false;
            chkFiltrarFecha.Enabled = false;
            dtpFechaInicio.Enabled = false;
            dtpFechaFin.Enabled = false;
            cmbEstado.Items.Clear();
            cmbMunicipio.Items.Clear();
            dgvReporte.DataSource = null;
            lblContadorRegistros.Text = "Esperando archivo";
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectorDeArchivo = new OpenFileDialog();
            selectorDeArchivo.Filter = "Archivos de Excel|*.xlsx";
            selectorDeArchivo.Title = "Selecciona el archivo de reporte";

            if (selectorDeArchivo.ShowDialog() == DialogResult.OK)
            {
                CargarReporteExcel(selectorDeArchivo.FileName);
            }
        }

        private void CargarReporteExcel(string rutaDelArchivo)
        {
            ConfigurarEstadoInicial();

            tablaDeDatos = new DataTable();
            tablaDeDatos.Columns.Add("ID", typeof(int));
            tablaDeDatos.Columns.Add("Entidad", typeof(string));
            tablaDeDatos.Columns.Add("Municipio", typeof(string));
            tablaDeDatos.Columns.Add("Nombre", typeof(string));
            tablaDeDatos.Columns.Add("FechaAfiliacion", typeof(DateTime));
            tablaDeDatos.Columns.Add("Estatus", typeof(string));

            try
            {
                using (var archivoExcel = new ExcelPackage(new System.IO.FileInfo(rutaDelArchivo)))
                {
                    ExcelWorksheet hojaDeCalculo = archivoExcel.Workbook.Worksheets[0];
                    int ultimaFila = hojaDeCalculo.Dimension.End.Row;// obtiene ultima

                    for (int i = 2; i <= ultimaFila; i++)
                    {
                        DataRow nuevaFila = tablaDeDatos.NewRow();
                        nuevaFila["ID"] = Convert.ToInt32(hojaDeCalculo.Cells[i, 1].Value);
                        nuevaFila["Entidad"] = hojaDeCalculo.Cells[i, 2].Value?.ToString();
                        nuevaFila["Municipio"] = hojaDeCalculo.Cells[i, 3].Value?.ToString();
                        nuevaFila["Nombre"] = hojaDeCalculo.Cells[i, 4].Value?.ToString();
                        nuevaFila["FechaAfiliacion"] = Convert.ToDateTime(hojaDeCalculo.Cells[i, 5].Value);
                        nuevaFila["Estatus"] = hojaDeCalculo.Cells[i, 6].Value?.ToString();
                        tablaDeDatos.Rows.Add(nuevaFila);
                    }
                }

                dgvReporte.DataSource = tablaDeDatos;

                var estadosUnicos = tablaDeDatos.AsEnumerable()//(Select, Distinct, OrderBy
                                       .Select(fila => fila.Field<string>("Entidad"))// de la lista solo neseito la columna entidad
                                        .Distinct()// de todos solo 1
                                        .OrderBy(e => e)// que los ordene
                                        .ToList();// en lista

                cmbEstado.Items.Add("TODOS");
                // Agregar estados al ComboBox
                foreach (var estado in estadosUnicos)
                {
                    cmbEstado.Items.Add(estado);
                }
                cmbEstado.SelectedIndex = 0;

                cmbEstado.Enabled = true;
                cmbMunicipio.Enabled = true;
                btnReset.Enabled = true;
                chkFiltrarFecha.Enabled = true;

                lblContadorRegistros.Text = $"Mostrando {tablaDeDatos.Rows.Count} registros.";
                MessageBox.Show("Carga completa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al leer el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltros()
        {
            if (tablaDeDatos == null) return;
            // crea una vista filtrable sobre los datos originales para no perderlos 
            DataView vistaFiltrada = tablaDeDatos.DefaultView;
            string textoDeFiltro = "";

            if (cmbEstado.SelectedItem != null && cmbEstado.SelectedItem.ToString() != "TODOS")
            {
                textoDeFiltro += $"Entidad = '{cmbEstado.SelectedItem}'";
            }

            if (cmbMunicipio.SelectedItem != null && cmbMunicipio.SelectedItem.ToString() != "TODOS")
            {
                // se asegura que no este vacio
                if (!string.IsNullOrEmpty(textoDeFiltro))
                {
                    textoDeFiltro += " AND ";
                }
                textoDeFiltro += $"Municipio = '{cmbMunicipio.SelectedItem}'";
            }

            if (chkFiltrarFecha.Checked)
            {
                if (!string.IsNullOrEmpty(textoDeFiltro))
                {
                    textoDeFiltro += " AND ";
                }
                // Formatea las fechas se combierten a texto
                string fechaInicio = dtpFechaInicio.Value.ToString("MM/dd/yyyy");
                string fechaFin = dtpFechaFin.Value.ToString("MM/dd/yyyy");
                textoDeFiltro += $"FechaAfiliacion >= #{fechaInicio}# AND FechaAfiliacion <= #{fechaFin}#";
            }

            vistaFiltrada.RowFilter = textoDeFiltro;
            dgvReporte.DataSource = vistaFiltrada;
            lblContadorRegistros.Text = $"Mostrando {vistaFiltrada.Count} de {tablaDeDatos.Rows.Count} registros";
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMunicipio.Items.Clear();
            cmbMunicipio.Items.Add("TODOS");
            string estadoSeleccionado = cmbEstado.SelectedItem.ToString();

            if (estadoSeleccionado != "TODOS")
            {
                var listaMunicipios = tablaDeDatos.AsEnumerable()
                    // se queda con la que coincida con el estado seleccionado
                    .Where(fila => fila.Field<string>("Entidad") == estadoSeleccionado)
                    // solo la que tiene el municipio
                    .Select(fila => fila.Field<string>("Municipio"))
                    .Distinct()// que no se repitan
                    .OrderBy(m => m)// alfabetico
                    .ToList();

                foreach (var municipio in listaMunicipios)
                {
                    cmbMunicipio.Items.Add(municipio);
                }
            }
            cmbMunicipio.SelectedIndex = 0;
            AplicarFiltros();
        }

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void chkFiltrarFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaInicio.Enabled = chkFiltrarFecha.Checked;
            dtpFechaFin.Enabled = chkFiltrarFecha.Checked;
            AplicarFiltros();
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
            {
                dtpFechaFin.Value = dtpFechaInicio.Value;
            }
            AplicarFiltros();
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaFin.Value < dtpFechaInicio.Value)
            {
                dtpFechaInicio.Value = dtpFechaFin.Value;
            }
            AplicarFiltros();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (tablaDeDatos == null) return;
            chkFiltrarFecha.Checked = false;
            dtpFechaInicio.Enabled = false;
            dtpFechaFin.Enabled = false;
            cmbEstado.SelectedIndex = 0;
            AplicarFiltros();
        }

        private void butExportar_Click(object sender, EventArgs e)
        {
            // Revisa si la tabla tiene filas. Si esta vacia, muestra un aviso y se detiene.
            if (dgvReporte.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            // Crea el objeto para el dialogo de guardado.
            SaveFileDialog dialogoGuardar = new SaveFileDialog();
            // Configura el filtro para que solo permita guardar como archivo CSV.
            dialogoGuardar.Filter = "Archivo CSV (*.csv)|*.csv";
            // Sugiere un nombre de archivo automatico con la fecha y hora actual para que sea unico.
            dialogoGuardar.FileName = $"exelPri_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            // Muestra la ventana. El codigo de adentro solo se ejecuta si el usuario presiona "Guardar".
            if (dialogoGuardar.ShowDialog() == DialogResult.OK)
            {
                // Inicia un bloque 'try-catch' como red de seguridad para atrapar cualquier error durante el guardado.
                try
                {
                    // --- Construccion del contenido del archivo en memoria ---
                    // Crea un 'StringBuilder', que es una herramienta eficiente para construir textos largos.
                    var constructorCsv = new StringBuilder();

                    // Obtiene una lista de todas las columnas de la tabla.
                    var encabezados = dgvReporte.Columns.Cast<DataGridViewColumn>();
                    // Une los nombres de los encabezados con comas y lo añade como la primera linea del texto.
                    constructorCsv.AppendLine(string.Join(",", encabezados.Select(columna => $"\"{columna.HeaderText}\"").ToArray()));

                    // Recorre cada fila ('fila') de la tabla visible ('dgvReporte').
                    foreach (DataGridViewRow fila in dgvReporte.Rows)
                    {
                        // Se asegura de ignorar la ultima fila en blanco que a veces se añade automaticamente.
                        if (!fila.IsNewRow)
                        {
                            // Obtiene una lista de todas las celdas de la fila actual.
                            var celdas = fila.Cells.Cast<DataGridViewCell>();
                            // Une los valores de las celdas con comas y lo añade como una nueva linea al texto.
                            constructorCsv.AppendLine(string.Join(",", celdas.Select(celda => $"\"{celda.Value}\"").ToArray()));
                        }
                    }

                    // --- Guardado del archivo en el disco ---
                    // Toma todo el texto construido en 'constructorCsv' y lo guarda en el archivo fisico.
                    System.IO.File.WriteAllText(dialogoGuardar.FileName, constructorCsv.ToString(), Encoding.UTF8);
                    // Muestra un mensaje al usuario confirmando que la exportacion fue exitosa.
                    MessageBox.Show("El archivo se ha exportado con éxito.", "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Si ocurre cualquier error, lo atrapa y muestra una ventana con el mensaje del error.
                    MessageBox.Show($"Ocurrió un error al exportar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Metodos vacios  ---
        private void Principal_Load(object sender, EventArgs e) { }
        private void dgvReporte_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}
namespace LectorDeReportesPri
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            dgvReporte = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colEntidad = new DataGridViewTextBoxColumn();
            colMunicipio = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colEstatus = new DataGridViewTextBoxColumn();
            menuStrip1 = new MenuStrip();
            btnReset = new Button();
            cmbEstado = new ComboBox();
            cmbMunicipio = new ComboBox();
            chkFiltrarFecha = new CheckBox();
            dtpFechaInicio = new DateTimePicker();
            label1 = new Label();
            dtpFechaFin = new DateTimePicker();
            label2 = new Label();
            statusStrip1 = new StatusStrip();
            lblContadorRegistros = new ToolStripStatusLabel();
            btnCargar = new Button();
            butExportar = new Button();
            label3 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvReporte);
            panel1.Location = new Point(12, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(797, 232);
            panel1.TabIndex = 0;
            // 
            // dgvReporte
            // 
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.BackgroundColor = Color.White;
            dgvReporte.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Gainsboro;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Columns.AddRange(new DataGridViewColumn[] { colID, colEntidad, colMunicipio, colNombre, colFecha, colEstatus });
            dgvReporte.Dock = DockStyle.Fill;
            dgvReporte.EnableHeadersVisualStyles = false;
            dgvReporte.GridColor = Color.LightGray;
            dgvReporte.Location = new Point(0, 0);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.Size = new Size(797, 232);
            dgvReporte.TabIndex = 0;
            dgvReporte.CellContentClick += dgvReporte_CellContentClick;
            // 
            // colID
            // 
            colID.DataPropertyName = "ID";
            colID.HeaderText = "ID";
            colID.Name = "colID";
            // 
            // colEntidad
            // 
            colEntidad.DataPropertyName = "ENTIDAD";
            colEntidad.HeaderText = "ENTIDAD";
            colEntidad.Name = "colEntidad";
            // 
            // colMunicipio
            // 
            colMunicipio.DataPropertyName = "MUNICIPIO";
            colMunicipio.HeaderText = "MUNICIPIO";
            colMunicipio.Name = "colMunicipio";
            // 
            // colNombre
            // 
            colNombre.DataPropertyName = "NOMBRE";
            colNombre.HeaderText = "NOMBRE";
            colNombre.Name = "colNombre";
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "FECHAAFILIACION";
            colFecha.HeaderText = "FECHA AFILIACION";
            colFecha.Name = "colFecha";
            // 
            // colEstatus
            // 
            colEstatus.DataPropertyName = "ESTATUS";
            colEstatus.HeaderText = "ESTATUS";
            colEstatus.Name = "colEstatus";
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(848, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.IndianRed;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 9.75F);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(726, 27);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(83, 32);
            btnReset.TabIndex = 2;
            btnReset.Text = "RESET";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // cmbEstado
            // 
            cmbEstado.BackColor = SystemColors.ControlLight;
            cmbEstado.FlatStyle = FlatStyle.System;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(352, 20);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 3;
            cmbEstado.Text = "ESTADO";
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;
            // 
            // cmbMunicipio
            // 
            cmbMunicipio.BackColor = SystemColors.ControlLight;
            cmbMunicipio.FlatStyle = FlatStyle.System;
            cmbMunicipio.FormattingEnabled = true;
            cmbMunicipio.Location = new Point(352, 75);
            cmbMunicipio.Name = "cmbMunicipio";
            cmbMunicipio.Size = new Size(121, 23);
            cmbMunicipio.TabIndex = 4;
            cmbMunicipio.Text = "MUNICIPIO";
            cmbMunicipio.SelectedIndexChanged += cmbMunicipio_SelectedIndexChanged;
            // 
            // chkFiltrarFecha
            // 
            chkFiltrarFecha.AutoSize = true;
            chkFiltrarFecha.BackColor = Color.WhiteSmoke;
            chkFiltrarFecha.FlatStyle = FlatStyle.Flat;
            chkFiltrarFecha.Location = new Point(11, 345);
            chkFiltrarFecha.Name = "chkFiltrarFecha";
            chkFiltrarFecha.Size = new Size(177, 19);
            chkFiltrarFecha.TabIndex = 5;
            chkFiltrarFecha.Text = "Filtrar por Fecha de Afiliacion";
            chkFiltrarFecha.UseVisualStyleBackColor = false;
            chkFiltrarFecha.CheckedChanged += chkFiltrarFecha_CheckedChanged;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(51, 382);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(209, 23);
            dtpFechaInicio.TabIndex = 6;
            dtpFechaInicio.ValueChanged += dtpFechaInicio_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(266, 384);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 7;
            label1.Text = "Hasta";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Location = new Point(309, 382);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(220, 23);
            dtpFechaFin.TabIndex = 8;
            dtpFechaFin.ValueChanged += dtpFechaFin_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 388);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 9;
            label2.Text = "Desde";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblContadorRegistros });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(848, 22);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblContadorRegistros
            // 
            lblContadorRegistros.Name = "lblContadorRegistros";
            lblContadorRegistros.Size = new Size(118, 17);
            lblContadorRegistros.Text = "toolStripStatusLabel1";
            // 
            // btnCargar
            // 
            btnCargar.BackColor = Color.Gainsboro;
            btnCargar.FlatStyle = FlatStyle.Flat;
            btnCargar.Font = new Font("Segoe UI", 9.75F);
            btnCargar.Location = new Point(12, 20);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(73, 30);
            btnCargar.TabIndex = 11;
            btnCargar.Text = "CARGAR";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;
            // 
            // butExportar
            // 
            butExportar.BackColor = Color.Gainsboro;
            butExportar.FlatStyle = FlatStyle.Flat;
            butExportar.Font = new Font("Segoe UI", 9.75F);
            butExportar.Location = new Point(100, 20);
            butExportar.Name = "butExportar";
            butExportar.Size = new Size(73, 30);
            butExportar.TabIndex = 12;
            butExportar.Text = "EXPORTAR";
            butExportar.UseVisualStyleBackColor = false;
            butExportar.Click += butExportar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(285, 24);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 13;
            label3.Text = "ESTADO";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(278, 78);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 14;
            label4.Text = "MUNICIPIO";
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(848, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(butExportar);
            Controls.Add(btnCargar);
            Controls.Add(statusStrip1);
            Controls.Add(label2);
            Controls.Add(dtpFechaFin);
            Controls.Add(label1);
            Controls.Add(dtpFechaInicio);
            Controls.Add(chkFiltrarFecha);
            Controls.Add(cmbMunicipio);
            Controls.Add(cmbEstado);
            Controls.Add(btnReset);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            ForeColor = Color.DimGray;
            MainMenuStrip = menuStrip1;
            Name = "Principal";
            Text = "Principal";
            Load += Principal_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvReporte;
        private MenuStrip menuStrip1;
        private Button btnReset;
        private ComboBox cmbEstado;
        private ComboBox cmbMunicipio;
        private CheckBox chkFiltrarFecha;
        private DateTimePicker dtpFechaInicio;
        private Label label1;
        private DateTimePicker dtpFechaFin;
        private Label label2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblContadorRegistros;
        private Button btnCargar;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colEntidad;
        private DataGridViewTextBoxColumn colMunicipio;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colEstatus;
        private Button butExportar;
        private Label label3;
        private Label label4;
    }
}
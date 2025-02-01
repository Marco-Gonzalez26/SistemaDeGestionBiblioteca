namespace SistemaDeGestionBiblioteca.Views.Home
{
    partial class UC_Home
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.report = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.Vista_PrestamosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistemaGestionBibliotecaDataSet = new SistemaDeGestionBiblioteca.SistemaGestionBibliotecaDataSet();
            this.vistaPrestamosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vista_PrestamosTableAdapter = new SistemaDeGestionBiblioteca.SistemaGestionBibliotecaDataSetTableAdapters.Vista_PrestamosTableAdapter();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vista_PrestamosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaGestionBibliotecaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaPrestamosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(695, 60);
            this.panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.panel1.Controls.Add(this.report);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 500);
            this.panel1.TabIndex = 0;
            // 
            // report
            // 
            this.report.AutoScroll = true;
            this.report.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Biblioteca";
            reportDataSource1.Value = this.Vista_PrestamosBindingSource;
            this.report.LocalReport.DataSources.Add(reportDataSource1);
            this.report.LocalReport.ReportEmbeddedResource = "SistemaDeGestionBiblioteca.Views.Home.Report.rdlc";
            this.report.Location = new System.Drawing.Point(0, 60);
            this.report.Name = "report";
            this.report.ServerReport.BearerToken = null;
            this.report.Size = new System.Drawing.Size(695, 440);
            this.report.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar por usuario";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(169, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(144, 28);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(319, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 32);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Vista_PrestamosBindingSource
            // 
            this.Vista_PrestamosBindingSource.DataMember = "Vista_Prestamos";
            this.Vista_PrestamosBindingSource.DataSource = this.sistemaGestionBibliotecaDataSet;
            // 
            // sistemaGestionBibliotecaDataSet
            // 
            this.sistemaGestionBibliotecaDataSet.DataSetName = "SistemaGestionBibliotecaDataSet";
            this.sistemaGestionBibliotecaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vistaPrestamosBindingSource
            // 
            this.vistaPrestamosBindingSource.DataMember = "Vista_Prestamos";
            this.vistaPrestamosBindingSource.DataSource = this.sistemaGestionBibliotecaDataSet;
            // 
            // vista_PrestamosTableAdapter
            // 
            this.vista_PrestamosTableAdapter.ClearBeforeFill = true;
            // 
            // UC_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(695, 500);
            this.MinimumSize = new System.Drawing.Size(695, 500);
            this.Name = "UC_Home";
            this.Size = new System.Drawing.Size(695, 500);
            this.Load += new System.EventHandler(this.UC_Home_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Vista_PrestamosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaGestionBibliotecaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaPrestamosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer report;
        private System.Windows.Forms.BindingSource Vista_PrestamosBindingSource;
        private SistemaGestionBibliotecaDataSet sistemaGestionBibliotecaDataSet;
        private System.Windows.Forms.BindingSource vistaPrestamosBindingSource;
        private SistemaGestionBibliotecaDataSetTableAdapters.Vista_PrestamosTableAdapter vista_PrestamosTableAdapter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}

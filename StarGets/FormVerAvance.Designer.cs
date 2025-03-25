namespace StarGets
{
    partial class FormVerAvance
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
            this.components = new System.ComponentModel.Container();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.cbOpciones = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.empleadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.starGetsDataSet = new StarGets.StarGetsDataSet();
            this.proyectosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proyectosTableAdapter = new StarGets.StarGetsDataSetTableAdapters.proyectosTableAdapter();
            this.empleadosTableAdapter = new StarGets.StarGetsDataSetTableAdapters.empleadosTableAdapter();
            this.lblResumen = new System.Windows.Forms.Label();
            this.dgvAvance = new System.Windows.Forms.DataGridView();
            this.starGetsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starGetsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starGetsDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFiltro
            // 
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Location = new System.Drawing.Point(201, 12);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(158, 24);
            this.cbFiltro.TabIndex = 0;
            this.cbFiltro.SelectedIndexChanged += new System.EventHandler(this.cbFiltro_SelectedIndexChanged);
            // 
            // cbOpciones
            // 
            this.cbOpciones.FormattingEnabled = true;
            this.cbOpciones.Location = new System.Drawing.Point(238, 56);
            this.cbOpciones.Name = "cbOpciones";
            this.cbOpciones.Size = new System.Drawing.Size(121, 24);
            this.cbOpciones.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(135, 106);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selección de tipo de vista";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lista de proyectos o colaboradores";
            // 
            // empleadosBindingSource
            // 
            this.empleadosBindingSource.DataMember = "empleados";
            this.empleadosBindingSource.DataSource = this.starGetsDataSet;
            // 
            // starGetsDataSet
            // 
            this.starGetsDataSet.DataSetName = "StarGetsDataSet";
            this.starGetsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // proyectosBindingSource
            // 
            this.proyectosBindingSource.DataMember = "proyectos";
            this.proyectosBindingSource.DataSource = this.starGetsDataSet;
            // 
            // proyectosTableAdapter
            // 
            this.proyectosTableAdapter.ClearBeforeFill = true;
            // 
            // empleadosTableAdapter
            // 
            this.empleadosTableAdapter.ClearBeforeFill = true;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Location = new System.Drawing.Point(406, 15);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(0, 16);
            this.lblResumen.TabIndex = 6;
            // 
            // dgvAvance
            // 
            this.dgvAvance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvance.Location = new System.Drawing.Point(15, 144);
            this.dgvAvance.Name = "dgvAvance";
            this.dgvAvance.RowHeadersWidth = 51;
            this.dgvAvance.RowTemplate.Height = 24;
            this.dgvAvance.Size = new System.Drawing.Size(690, 150);
            this.dgvAvance.TabIndex = 7;
            // 
            // starGetsDataSetBindingSource
            // 
            this.starGetsDataSetBindingSource.DataSource = this.starGetsDataSet;
            this.starGetsDataSetBindingSource.Position = 0;
            // 
            // FormVerAvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 317);
            this.Controls.Add(this.dgvAvance);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbOpciones);
            this.Controls.Add(this.cbFiltro);
            this.Name = "FormVerAvance";
            this.Text = "FormVerAvance";
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starGetsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starGetsDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.ComboBox cbOpciones;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private StarGetsDataSet starGetsDataSet;
        private System.Windows.Forms.BindingSource proyectosBindingSource;
        private StarGetsDataSetTableAdapters.proyectosTableAdapter proyectosTableAdapter;
        private System.Windows.Forms.BindingSource empleadosBindingSource;
        private StarGetsDataSetTableAdapters.empleadosTableAdapter empleadosTableAdapter;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.DataGridView dgvAvance;
        private System.Windows.Forms.BindingSource starGetsDataSetBindingSource;
    }
}
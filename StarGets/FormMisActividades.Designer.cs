namespace StarGets
{
    partial class FormMisActividades
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
            this.dgvMisActividades = new System.Windows.Forms.DataGridView();
            this.actividadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.starGetsDataSet = new StarGets.StarGetsDataSet();
            this.actividadesTableAdapter = new StarGets.StarGetsDataSetTableAdapters.actividadesTableAdapter();
            this.cbEstadoNuevo = new System.Windows.Forms.ComboBox();
            this.txtArchivoNuevo = new System.Windows.Forms.TextBox();
            this.btnSubirArchivo = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisActividades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starGetsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMisActividades
            // 
            this.dgvMisActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMisActividades.Location = new System.Drawing.Point(12, 12);
            this.dgvMisActividades.Name = "dgvMisActividades";
            this.dgvMisActividades.RowHeadersWidth = 51;
            this.dgvMisActividades.RowTemplate.Height = 24;
            this.dgvMisActividades.Size = new System.Drawing.Size(419, 219);
            this.dgvMisActividades.TabIndex = 0;
            this.dgvMisActividades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMisActividades_CellContentClick);
            // 
            // actividadesBindingSource
            // 
            this.actividadesBindingSource.DataMember = "actividades";
            this.actividadesBindingSource.DataSource = this.starGetsDataSet;
            // 
            // starGetsDataSet
            // 
            this.starGetsDataSet.DataSetName = "StarGetsDataSet";
            this.starGetsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // actividadesTableAdapter
            // 
            this.actividadesTableAdapter.ClearBeforeFill = true;
            // 
            // cbEstadoNuevo
            // 
            this.cbEstadoNuevo.FormattingEnabled = true;
            this.cbEstadoNuevo.Location = new System.Drawing.Point(584, 56);
            this.cbEstadoNuevo.Name = "cbEstadoNuevo";
            this.cbEstadoNuevo.Size = new System.Drawing.Size(200, 24);
            this.cbEstadoNuevo.TabIndex = 1;
            // 
            // txtArchivoNuevo
            // 
            this.txtArchivoNuevo.Location = new System.Drawing.Point(547, 101);
            this.txtArchivoNuevo.Name = "txtArchivoNuevo";
            this.txtArchivoNuevo.Size = new System.Drawing.Size(237, 22);
            this.txtArchivoNuevo.TabIndex = 2;
            // 
            // btnSubirArchivo
            // 
            this.btnSubirArchivo.Location = new System.Drawing.Point(466, 145);
            this.btnSubirArchivo.Name = "btnSubirArchivo";
            this.btnSubirArchivo.Size = new System.Drawing.Size(75, 23);
            this.btnSubirArchivo.TabIndex = 3;
            this.btnSubirArchivo.Text = "Subir";
            this.btnSubirArchivo.UseVisualStyleBackColor = true;
            this.btnSubirArchivo.Click += new System.EventHandler(this.btnSubirArchivo_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(466, 185);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(438, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Estado de la actividad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ruta del archivo";
            // 
            // FormMisActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 260);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnSubirArchivo);
            this.Controls.Add(this.txtArchivoNuevo);
            this.Controls.Add(this.cbEstadoNuevo);
            this.Controls.Add(this.dgvMisActividades);
            this.Name = "FormMisActividades";
            this.Text = "FormMisActividades";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisActividades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starGetsDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMisActividades;
        private StarGetsDataSet starGetsDataSet;
        private System.Windows.Forms.BindingSource actividadesBindingSource;
        private StarGetsDataSetTableAdapters.actividadesTableAdapter actividadesTableAdapter;
        private System.Windows.Forms.ComboBox cbEstadoNuevo;
        private System.Windows.Forms.TextBox txtArchivoNuevo;
        private System.Windows.Forms.Button btnSubirArchivo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
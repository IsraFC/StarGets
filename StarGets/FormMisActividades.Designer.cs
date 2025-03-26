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
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisActividades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starGetsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMisActividades
            // 
            this.dgvMisActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMisActividades.Location = new System.Drawing.Point(12, 247);
            this.dgvMisActividades.Name = "dgvMisActividades";
            this.dgvMisActividades.RowHeadersWidth = 51;
            this.dgvMisActividades.RowTemplate.Height = 24;
            this.dgvMisActividades.Size = new System.Drawing.Size(656, 219);
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
            this.cbEstadoNuevo.Location = new System.Drawing.Point(175, 118);
            this.cbEstadoNuevo.Name = "cbEstadoNuevo";
            this.cbEstadoNuevo.Size = new System.Drawing.Size(237, 24);
            this.cbEstadoNuevo.TabIndex = 1;
            // 
            // txtArchivoNuevo
            // 
            this.txtArchivoNuevo.Location = new System.Drawing.Point(175, 165);
            this.txtArchivoNuevo.Name = "txtArchivoNuevo";
            this.txtArchivoNuevo.Size = new System.Drawing.Size(237, 22);
            this.txtArchivoNuevo.TabIndex = 2;
            // 
            // btnSubirArchivo
            // 
            this.btnSubirArchivo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSubirArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirArchivo.Location = new System.Drawing.Point(17, 67);
            this.btnSubirArchivo.Name = "btnSubirArchivo";
            this.btnSubirArchivo.Size = new System.Drawing.Size(128, 27);
            this.btnSubirArchivo.TabIndex = 3;
            this.btnSubirArchivo.Text = "Subir actividad";
            this.btnSubirArchivo.UseVisualStyleBackColor = false;
            this.btnSubirArchivo.Click += new System.EventHandler(this.btnSubirArchivo_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(175, 67);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(128, 27);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Estado de la actividad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ruta del archivo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 37);
            this.label3.TabIndex = 7;
            this.label3.Text = "Actividades";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::StarGets.Properties.Resources.myactivity;
            this.pictureBox3.Location = new System.Drawing.Point(12, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.Location = new System.Drawing.Point(9, 223);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(165, 18);
            this.lblRegistro.TabIndex = 24;
            this.lblRegistro.Text = "Registro de actividades:";
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(590, 499);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(119, 32);
            this.btnRegresar.TabIndex = 26;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // FormMisActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 543);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label3);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Button btnRegresar;
    }
}
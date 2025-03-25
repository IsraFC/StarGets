namespace StarGets
{
    partial class FormActividades
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
            this.cbProyecto = new System.Windows.Forms.ComboBox();
            this.cbColaborador = new System.Windows.Forms.ComboBox();
            this.txtNombreActividad = new System.Windows.Forms.TextBox();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpEntrega = new System.Windows.Forms.DateTimePicker();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvActividades = new System.Windows.Forms.DataGridView();
            this.actividadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.starGetsDataSet = new StarGets.StarGetsDataSet();
            this.starGetsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.actividadesTableAdapter = new StarGets.StarGetsDataSetTableAdapters.actividadesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starGetsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starGetsDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cbProyecto
            // 
            this.cbProyecto.FormattingEnabled = true;
            this.cbProyecto.Location = new System.Drawing.Point(210, 14);
            this.cbProyecto.Name = "cbProyecto";
            this.cbProyecto.Size = new System.Drawing.Size(205, 24);
            this.cbProyecto.TabIndex = 0;
            // 
            // cbColaborador
            // 
            this.cbColaborador.FormattingEnabled = true;
            this.cbColaborador.Location = new System.Drawing.Point(210, 57);
            this.cbColaborador.Name = "cbColaborador";
            this.cbColaborador.Size = new System.Drawing.Size(205, 24);
            this.cbColaborador.TabIndex = 1;
            // 
            // txtNombreActividad
            // 
            this.txtNombreActividad.Location = new System.Drawing.Point(209, 97);
            this.txtNombreActividad.Name = "txtNombreActividad";
            this.txtNombreActividad.Size = new System.Drawing.Size(206, 22);
            this.txtNombreActividad.TabIndex = 2;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(210, 142);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(205, 22);
            this.dtpInicio.TabIndex = 3;
            // 
            // dtpEntrega
            // 
            this.dtpEntrega.Location = new System.Drawing.Point(210, 185);
            this.dtpEntrega.Name = "dtpEntrega";
            this.dtpEntrega.Size = new System.Drawing.Size(205, 22);
            this.dtpEntrega.TabIndex = 4;
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(210, 227);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(205, 24);
            this.cbEstado.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(210, 270);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(205, 22);
            this.txtDescripcion.TabIndex = 6;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(432, 97);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 23);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(432, 141);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 23);
            this.btnActualizar.TabIndex = 9;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(432, 185);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 23);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(432, 227);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 23);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "\tSelección de proyecto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "\tSelección de colaborador";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "\tNombre de la actividad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "\tFecha de inicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Fecha de entrega";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Estado de la actividad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "\tDescripción detallada";
            // 
            // dgvActividades
            // 
            this.dgvActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActividades.Location = new System.Drawing.Point(547, 12);
            this.dgvActividades.Name = "dgvActividades";
            this.dgvActividades.RowHeadersWidth = 51;
            this.dgvActividades.RowTemplate.Height = 24;
            this.dgvActividades.Size = new System.Drawing.Size(339, 321);
            this.dgvActividades.TabIndex = 19;
            this.dgvActividades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActividades_CellContentClick);
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
            // starGetsDataSetBindingSource
            // 
            this.starGetsDataSetBindingSource.DataSource = this.starGetsDataSet;
            this.starGetsDataSetBindingSource.Position = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Ruta de archivo";
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(210, 312);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(205, 22);
            this.txtArchivo.TabIndex = 21;
            // 
            // actividadesTableAdapter
            // 
            this.actividadesTableAdapter.ClearBeforeFill = true;
            // 
            // FormActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 351);
            this.Controls.Add(this.txtArchivo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvActividades);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.dtpEntrega);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.txtNombreActividad);
            this.Controls.Add(this.cbColaborador);
            this.Controls.Add(this.cbProyecto);
            this.Name = "FormActividades";
            this.Text = "FormActividades";
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starGetsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starGetsDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProyecto;
        private System.Windows.Forms.ComboBox cbColaborador;
        private System.Windows.Forms.TextBox txtNombreActividad;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpEntrega;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvActividades;
        private System.Windows.Forms.BindingSource starGetsDataSetBindingSource;
        private StarGetsDataSet starGetsDataSet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.BindingSource actividadesBindingSource;
        private StarGetsDataSetTableAdapters.actividadesTableAdapter actividadesTableAdapter;
    }
}
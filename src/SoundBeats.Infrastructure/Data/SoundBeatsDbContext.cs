using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SoundBeats.Core.Domain;
using SoundBeats.Infrastructure;

namespace SoundBeats.Infrastructure.Data
{
    public partial class SoundBeatsDbContext : DbContext
    {
        public SoundBeatsDbContext()
        {
        }

        public SoundBeatsDbContext(DbContextOptions<SoundBeatsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<CategoriaProductos> CategoriaProductos { get; set; }
        public virtual DbSet<CategoriaTercero> CategoriaTercero { get; set; }
        public virtual DbSet<DetalleRegistroCompras> DetalleRegistroCompras { get; set; }
        public virtual DbSet<DetalleRegistroInventarios> DetalleRegistroInventarios { get; set; }
        public virtual DbSet<DetalleRegistroVentas> DetalleRegistroVentas { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<RegRoles> RegRoles { get; set; }
        public virtual DbSet<RegistroCompras> RegistroCompras { get; set; }
        public virtual DbSet<RegistroInventario> RegistroInventario { get; set; }
        public virtual DbSet<RegistroVentas> RegistroVentas { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Terceros> Terceros { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("database=base_siicore;server=localhost;port=3306;user=root;password=root");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargos>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("PRIMARY");

                entity.ToTable("cargos");

                entity.Property(e => e.IdCargo).HasColumnName("id_cargo");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.NombreCargo)
                    .IsRequired()
                    .HasColumnName("nombre_cargo")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<CategoriaProductos>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaProducto)
                    .HasName("PRIMARY");

                entity.ToTable("categoria_productos");

                entity.Property(e => e.IdCategoriaProducto).HasColumnName("id_categoria_producto");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(250);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CategoriaTercero>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaTercero)
                    .HasName("PRIMARY");

                entity.ToTable("categoria_tercero");

                entity.Property(e => e.IdCategoriaTercero).HasColumnName("id_categoria_tercero");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DetalleRegistroCompras>(entity =>
            {
                entity.HasKey(e => e.IdDetalleRegistroCompra)
                    .HasName("PRIMARY");

                entity.ToTable("detalle_registro_compras");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("FK_detalle_registro_compras_productos");

                entity.HasIndex(e => e.IdRegistroCompra)
                    .HasName("FK_detalle_registro_compras_registro_compras");

                entity.Property(e => e.IdDetalleRegistroCompra).HasColumnName("id_detalle_registro_compra");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Descuento)
                    .HasColumnName("descuento")
                    .HasColumnType("decimal(2,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.IdRegistroCompra).HasColumnName("id_registro_compra");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(2,0)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleRegistroCompras)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_registro_compras_productos");

                entity.HasOne(d => d.IdRegistroCompraNavigation)
                    .WithMany(p => p.DetalleRegistroCompras)
                    .HasForeignKey(d => d.IdRegistroCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_registro_compras_registro_compras");
            });

            modelBuilder.Entity<DetalleRegistroInventarios>(entity =>
            {
                entity.HasKey(e => e.IdDetalleRegistroInventario)
                    .HasName("PRIMARY");

                entity.ToTable("detalle_registro_inventarios");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("FK_detalle_registro_inventarios_productos");

                entity.HasIndex(e => e.IdRegistroInventario)
                    .HasName("FK_detalle_registro_inventarios_registro_inventario");

                entity.Property(e => e.IdDetalleRegistroInventario).HasColumnName("id_detalle_registro_inventario");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.IdRegistroInventario).HasColumnName("id_registro_inventario");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(2,0)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleRegistroInventarios)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_registro_inventarios_productos");

                entity.HasOne(d => d.IdRegistroInventarioNavigation)
                    .WithMany(p => p.DetalleRegistroInventarios)
                    .HasForeignKey(d => d.IdRegistroInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_registro_inventarios_registro_inventario");
            });

            modelBuilder.Entity<DetalleRegistroVentas>(entity =>
            {
                entity.HasKey(e => e.IdDetalleRegistroVentas)
                    .HasName("PRIMARY");

                entity.ToTable("detalle_registro_ventas");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("FK_detalle_registro_ventas_productos");

                entity.HasIndex(e => e.IdRegistroVenta)
                    .HasName("FK_detalle_registro_ventas_registro_ventas");

                entity.Property(e => e.IdDetalleRegistroVentas).HasColumnName("id_detalle_registro_ventas");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Descuento)
                    .HasColumnName("descuento")
                    .HasColumnType("decimal(10,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.IdRegistroVenta).HasColumnName("id_registro_venta");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleRegistroVentas)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_registro_ventas_productos");

                entity.HasOne(d => d.IdRegistroVentaNavigation)
                    .WithMany(p => p.DetalleRegistroVentas)
                    .HasForeignKey(d => d.IdRegistroVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_registro_ventas_registro_ventas");
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PRIMARY");

                entity.ToTable("empleados");

                entity.HasIndex(e => e.IdCargo)
                    .HasName("FK_empleados_cargos");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("FK_empleados_usuarios");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasColumnName("apellido_1")
                    .HasMaxLength(45);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasColumnName("apellido_2")
                    .HasMaxLength(45);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdCargo).HasColumnName("id_cargo");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasColumnName("nombre_1")
                    .HasMaxLength(45);

                entity.Property(e => e.Nombre2)
                    .IsRequired()
                    .HasColumnName("nombre_2")
                    .HasMaxLength(45);

                entity.Property(e => e.NumDocumento)
                    .IsRequired()
                    .HasColumnName("num_documento")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasColumnName("tipo_documento")
                    .HasMaxLength(2);

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdCargo)
                    .HasConstraintName("FK_empleados_cargos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empleados_usuarios");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("productos");

                entity.HasIndex(e => e.IdCategoriaProducto)
                    .HasName("FK_productos_categoria_productos");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("codigo")
                    .HasMaxLength(45);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(255);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.IdCategoriaProducto).HasColumnName("id_categoria_producto");

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .HasMaxLength(45);

                entity.Property(e => e.Lado)
                    .HasColumnName("lado")
                    .HasMaxLength(45);

                entity.Property(e => e.MarcaCoche)
                    .IsRequired()
                    .HasColumnName("marca_coche")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MarcaProducto)
                    .IsRequired()
                    .HasColumnName("marca_producto")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasColumnName("modelo")
                    .HasMaxLength(45);

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasColumnName("nombre_producto")
                    .HasMaxLength(100);

                entity.Property(e => e.PrecioCompra)
                    .HasColumnName("precio_compra")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.PrecioVenta)
                    .HasColumnName("precio_venta")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasColumnName("referencia")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasColumnName("ubicacion")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdCategoriaProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoriaProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_productos_categoria_productos");
            });

            modelBuilder.Entity<RegRoles>(entity =>
            {
                entity.HasKey(e => e.IdRegRol)
                    .HasName("PRIMARY");

                entity.ToTable("reg_roles");

                entity.Property(e => e.IdRegRol).HasColumnName("id_reg_rol");

                entity.Property(e => e.Accion)
                    .HasColumnName("accion")
                    .HasMaxLength(50);

                entity.Property(e => e.DescripcionRol)
                    .IsRequired()
                    .HasColumnName("descripcion_rol")
                    .HasMaxLength(200);

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasColumnName("nombre_rol")
                    .HasMaxLength(45);

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RegistroCompras>(entity =>
            {
                entity.HasKey(e => e.IdRegistroCompra)
                    .HasName("PRIMARY");

                entity.ToTable("registro_compras");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("FK_registro_compras_empleados");

                entity.HasIndex(e => e.IdTercero)
                    .HasName("FK_registro_compras_terceros");

                entity.Property(e => e.IdRegistroCompra).HasColumnName("id_registro_compra");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.IdTercero).HasColumnName("id_tercero");

                entity.Property(e => e.Impuesto)
                    .HasColumnName("impuesto")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.NumComprobante)
                    .IsRequired()
                    .HasColumnName("num_comprobante")
                    .HasMaxLength(20);

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.TipoComprobante)
                    .IsRequired()
                    .HasColumnName("tipo_comprobante")
                    .HasMaxLength(3);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.RegistroCompras)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registro_compras_empleados");

                entity.HasOne(d => d.IdTerceroNavigation)
                    .WithMany(p => p.RegistroCompras)
                    .HasForeignKey(d => d.IdTercero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registro_compras_terceros");
            });

            modelBuilder.Entity<RegistroInventario>(entity =>
            {
                entity.HasKey(e => e.IdRegistroInventario)
                    .HasName("PRIMARY");

                entity.ToTable("registro_inventario");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("FK_registro_inventario_terceros");

                entity.HasIndex(e => e.IdTercero)
                    .HasName("FK_registro_inventario_proveedores");

                entity.Property(e => e.IdRegistroInventario).HasColumnName("id_registro_inventario");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.IdTercero).HasColumnName("id_tercero");

                entity.Property(e => e.NumComprobante)
                    .IsRequired()
                    .HasColumnName("num_comprobante")
                    .HasMaxLength(10);

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.TipoComprobante)
                    .IsRequired()
                    .HasColumnName("tipo_comprobante")
                    .HasMaxLength(10);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.RegistroInventario)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registro_inventario_empleados");

                entity.HasOne(d => d.IdTerceroNavigation)
                    .WithMany(p => p.RegistroInventario)
                    .HasForeignKey(d => d.IdTercero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registro_inventario_terceros");
            });

            modelBuilder.Entity<RegistroVentas>(entity =>
            {
                entity.HasKey(e => e.IdRegistroVenta)
                    .HasName("PRIMARY");

                entity.ToTable("registro_ventas");

                entity.HasIndex(e => e.IdEmpleado)
                    .HasName("FK_registro_ventas_empleados");

                entity.HasIndex(e => e.IdTercero)
                    .HasName("FK_registro_ventas_terceros");

                entity.Property(e => e.IdRegistroVenta).HasColumnName("id_registro_venta");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.IdTercero).HasColumnName("id_tercero");

                entity.Property(e => e.Impuesto)
                    .HasColumnName("impuesto")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.NumComprobante)
                    .IsRequired()
                    .HasColumnName("num_comprobante")
                    .HasMaxLength(10);

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.TipoComprobante)
                    .IsRequired()
                    .HasColumnName("tipo_comprobante")
                    .HasMaxLength(20);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.RegistroVentas)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registro_ventas_empleados");

                entity.HasOne(d => d.IdTerceroNavigation)
                    .WithMany(p => p.RegistroVentas)
                    .HasForeignKey(d => d.IdTercero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registro_ventas_terceros");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.DescripcionRol)
                    .IsRequired()
                    .HasColumnName("descripcion_rol")
                    .HasMaxLength(200);

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasColumnName("nombre_rol")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Terceros>(entity =>
            {
                entity.HasKey(e => e.IdTercero)
                    .HasName("PRIMARY");

                entity.ToTable("terceros");

                entity.HasIndex(e => e.IdCategoriaTercero)
                    .HasName("FK_terceros_categoria_tercero");

                entity.Property(e => e.IdTercero).HasColumnName("id_tercero");

                entity.Property(e => e.Apellido1)
                    .HasColumnName("apellido_1")
                    .HasMaxLength(45);

                entity.Property(e => e.Apellido2)
                    .HasColumnName("apellido_2")
                    .HasMaxLength(45);

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(100);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.IdCategoriaTercero).HasColumnName("id_categoria_tercero");

                entity.Property(e => e.Nombre1)
                    .HasColumnName("nombre_1")
                    .HasMaxLength(45);

                entity.Property(e => e.Nombre2)
                    .HasColumnName("nombre_2")
                    .HasMaxLength(45);

                entity.Property(e => e.NumDocumento)
                    .IsRequired()
                    .HasColumnName("num_documento")
                    .HasMaxLength(20);

                entity.Property(e => e.PersonaContacto)
                    .HasColumnName("persona_contacto")
                    .HasMaxLength(200);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasColumnName("razon_social")
                    .HasMaxLength(200);

                entity.Property(e => e.TelefonContacto)
                    .HasColumnName("telefon_contacto")
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(45);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasColumnName("tipo_documento")
                    .HasMaxLength(3);

                entity.HasOne(d => d.IdCategoriaTerceroNavigation)
                    .WithMany(p => p.Terceros)
                    .HasForeignKey(d => d.IdCategoriaTercero)
                    .HasConstraintName("FK_terceros_categoria_tercero");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.IdRol)
                    .HasName("FK_usuarios_roles");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuarios_roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

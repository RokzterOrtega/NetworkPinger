Imports System.IO
Imports System.Net.NetworkInformation       ' Para operaciones asíncronas
Imports System.ComponentModel


Public Class Form1
    Private dbHelper As New DatabaseHelper()
    Private selectedDeviceId As Integer = -1 ' Para guardar el ID del equipo seleccionado en el DataGridView
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property AwaitTask As Object

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configurar DataGridView
        dgvDevices.AutoGenerateColumns = False ' Evita que se generen columnas automáticamente
        dgvDevices.Columns.Add("Id", "ID")
        dgvDevices.Columns("Id").DataPropertyName = "Id"
        dgvDevices.Columns("Id").Visible = False ' Ocultar la columna ID

        dgvDevices.Columns.Add("IpAddress", "Dirección IP / Hostname")
        dgvDevices.Columns("IpAddress").DataPropertyName = "IpAddress"
        dgvDevices.Columns("IpAddress").Width = 150

        dgvDevices.Columns.Add("Description", "Descripción")
        dgvDevices.Columns("Description").DataPropertyName = "Description"
        dgvDevices.Columns("Description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Await LoadDevicesAsync() ' Cargar equipos al iniciar el formulario
    End Sub

    Private Async Function LoadDevicesAsync() As Task
        Try
            Dim devices As List(Of Device) = Await Task.Run(Function() dbHelper.GetDevices())
            dgvDevices.DataSource = devices
            ClearInputFields()
        Catch ex As Exception
            MessageBox.Show($"Error al cargar equipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub ClearInputFields()
        txtIpAddress.Clear()
        txtDescription.Clear()
        selectedDeviceId = -1 ' Reiniciar el ID seleccionado
        btnAdd.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Async Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim ip As String = txtIpAddress.Text.Trim()
        Dim desc As String = txtDescription.Text.Trim()

        If String.IsNullOrWhiteSpace(ip) Then 'validacion de que el campo no este vacio
            MessageBox.Show("La dirección IP/Hostname no puede estar vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'aqui se tratara de parsear la direccion ip´
        Dim parsedIp As System.Net.IPAddress

        If Net.IPAddress.TryParse(ip, address:=parsedIp) Then
        Else
            If ip.Contains(".") OrElse ip.Contains(":") Then
                MessageBox.Show("La dirección IP/Hostname no es válida. Asegúrate de que sea una dirección IP válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        Try
            Await Task.Run(Sub() dbHelper.AddDevice(ip, desc))
            MessageBox.Show("Equipo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Await LoadDevicesAsync()
        Catch ex As Exception
            MessageBox.Show($"Error al agregar equipo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedDeviceId = -1 Then
            MessageBox.Show("Selecciona un equipo para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim ip As String = txtIpAddress.Text.Trim()
        Dim desc As String = txtDescription.Text.Trim()


        If String.IsNullOrWhiteSpace(ip) Then
            MessageBox.Show("La dirección IP / Hostname no puede estar vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim parsedIp As System.Net.IPAddress

        If Net.IPAddress.TryParse(ip, address:=parsedIp) Then

        Else

            If ip.Contains(".") OrElse ip.Contains(":") Then
                MessageBox.Show("El formato de la dirección IP no es válido. Por favor, introduce una IP válida (ej. 192.168.1.1).", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        Try
            Await Task.Run(Sub() dbHelper.UpdateDevice(selectedDeviceId, ip, desc))
            MessageBox.Show("Equipo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Await LoadDevicesAsync()
        Catch ex As Exception
            MessageBox.Show($"Error al actualizar equipo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedDeviceId = -1 Then
            MessageBox.Show("Selecciona un equipo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("¿Estás seguro de que quieres eliminar este equipo?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Await Task.Run(Sub() dbHelper.DeleteDevice(selectedDeviceId))
                MessageBox.Show("Equipo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Await LoadDevicesAsync()
            Catch ex As Exception
                MessageBox.Show($"Error al eliminar equipo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub dgvDevices_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDevices.SelectionChanged
        If dgvDevices.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvDevices.SelectedRows(0)
            Dim device As Device = TryCast(selectedRow.DataBoundItem, Device)
            If device IsNot Nothing Then
                selectedDeviceId = device.Id
                txtIpAddress.Text = device.IpAddress
                txtDescription.Text = device.Description
                btnAdd.Enabled = False
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
            End If
        Else
            ClearInputFields()
        End If
    End Sub

    Private Async Sub btnPing_Click(sender As Object, e As EventArgs) Handles btnPing.Click
        lbResults.Items.Clear() ' Limpiar resultados anteriores
        pbPing.Value = 0
        pbPing.Maximum = 0

        Dim devicesToPing As List(Of Device) = TryCast(dgvDevices.DataSource, List(Of Device))

        If devicesToPing Is Nothing OrElse devicesToPing.Count = 0 Then
            MessageBox.Show("No hay equipos para hacer ping.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        pbPing.Maximum = devicesToPing.Count
        pbPing.Value = 0

        Dim unreachableDevices As New List(Of String)
        Dim pingTasks As New List(Of Task(Of PingReply))

        ' Crear una lista de tareas de ping
        For Each device In devicesToPing
            pingTasks.Add(PingDeviceAsync(device.IpAddress))
        Next

        ' Esperar por cada tarea y actualizar la UI
        For i As Integer = 0 To pingTasks.Count - 1
            Dim device As Device = devicesToPing(i)
            Dim reply As PingReply = Nothing
            Try
                reply = Await pingTasks(i) ' Esperar por el resultado de la tarea actual
            Catch ex As Exception
                ' Esto captura excepciones si la IP no es válida o hay problemas de red
                reply = Nothing ' Indicar que hubo un error o no se pudo hacer ping
            End Try

            If reply Is Nothing OrElse reply.Status <> IPStatus.Success Then
                unreachableDevices.Add($"{device.Description} ({device.IpAddress})")
                lbResults.Items.Add($"❌ {device.Description} ({device.IpAddress}) - No Alcanzado")
            Else
                lbResults.Items.Add($"✅ {device.Description} ({device.IpAddress}) - Alcanzado (Tiempo: {reply.RoundtripTime}ms)")
            End If

            pbPing.Value += 1 ' Actualizar la barra de progreso
        Next

        If unreachableDevices.Count > 0 Then
            MessageBox.Show($"Los siguientes equipos no fueron alcanzados:{Environment.NewLine}{String.Join(Environment.NewLine, unreachableDevices)}", "Resultados del Ping", CType(CStr(MessageBoxButtons.OK), MessageBoxButtons), MessageBoxIcon.Warning)
        Else
            MessageBox.Show("¡Todos los equipos fueron alcanzados! Todos los equipos están encendidos.",
                            "Resultados del Ping", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Async Function PingDeviceAsync(ipAddress As String) As Task(Of PingReply)
        Using pinger As New Ping()
            Dim reply As PingReply = Nothing
            Try
                ' Timeout de 4 segundos (4000 milisegundos)
                reply = Await pinger.SendPingAsync(ipAddress, 4000)
            Catch ex As PingException
                ' Esto captura errores específicos del ping, como "Host desconocido"
                ' Puedes loguear el error si lo deseas: Console.WriteLine($"Ping error for {ipAddress}:  {ex.Message}")
                Return Nothing ' Retornar Nothing o un PingReply con un estado de error
            Catch ex As Exception
                ' Capturar cualquier otra excepción inesperada
                Return Nothing
            End Try
            Return reply
        End Using
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("Esta aplicacion fue desarrollada por JORTEGAE enn el IEPC. Espero que sea de utilidad  =)")

    End Sub

    Private Async Sub btnExportDb_Click(sender As Object, e As EventArgs) Handles btnExportDb.Click
        Using saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Archivos de Base de Datos SQLite (*.db)|*.db|Todos los archivos (*.*)|*.*"
            saveFileDialog.FileName = "devices.db" ' Nombre de archivo predeterminado

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim sourceFilePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "devices.db")
                Dim destinationFilePath As String = saveFileDialog.FileName

                If Not File.Exists(sourceFilePath) Then
                    MessageBox.Show("La base de datos 'devices.db' no se encontró en la ubicación de la aplicación.", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Try
                    ' Copiar el archivo de forma asíncrona para no bloquear la UI
                    Await Task.Run(Sub() File.Copy(sourceFilePath, destinationFilePath, True)) ' True para sobrescribir si existe
                    MessageBox.Show("Base de datos exportada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show($"Error al exportar la base de datos: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Async Function BtnImportDb_ClickAsync(sender As Object, e As EventArgs) As Task Handles btnImportDb.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Archivos de Base de Datos SQLite (*.db)|*.db|Todos los archivos (*.*)|*.*"
            openFileDialog.FileName = "devices.db" ' Nombre de archivo predeterminado

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim sourceFilePath As String = openFileDialog.FileName
                Dim destinationFilePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "devices.db")

                If Not File.Exists(sourceFilePath) Then
                    MessageBox.Show("El archivo de base de datos seleccionado no existe.", "Error de Importación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                If MessageBox.Show("¿Estás seguro de que quieres importar esta base de datos? Esto reemplazará la base de datos actual.", "Confirmar Importación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    Try
                        ' Antes de copiar, asegúrate de que la base de datos actual no esté en uso.
                        ' La forma más segura es "reiniciar" el dbHelper para liberar cualquier conexión abierta.
                        ' Aunque los "Using" en DatabaseHelper deberían cerrar las conexiones,
                        ' esta es una medida extra de seguridad para asegurar que el archivo no esté bloqueado.
                        dbHelper = Nothing ' Libera la referencia actual
                        GC.Collect()       ' Fuerza la recolección de basura (no siempre instantánea, pero ayuda)
                        GC.WaitForPendingFinalizers() ' Espera a que los finalizadores terminen

                        ' Copiar el archivo de forma asíncrona
                        Await Task.Run(Sub() File.Copy(sourceFilePath, destinationFilePath, True)) ' True para sobrescribir

                        ' Re-inicializar el dbHelper después de la copia
                        dbHelper = New DatabaseHelper()

                        ' Recargar los equipos en la interfaz de usuario
                        Await LoadDevicesAsync()

                        MessageBox.Show("Base de datos importada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show($"Error al importar la base de datos: {ex.Message}{Environment.NewLine}Asegúrate de que el programa no esté usando la base de datos o que no haya permisos de escritura.", "Error de Importación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            End If
        End Using
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim helpText As String = ""

        helpText &= "¡Bienvenido al pingeador! Aquí te explico cómo usarlo:" & Environment.NewLine & Environment.NewLine

        helpText &= "1. Gestión de Equipos:" & Environment.NewLine
        helpText &= "   - Para AGREGAR un nuevo equipo: Ingresa la 'Dirección IP  y una 'Descripción' (ej. 'Ironman | L27', 'PCB | D2'), luego haz clic en el botón 'Agregar Equipo'." & Environment.NewLine
        helpText &= "   - Para ACTUALIZAR los datos un equipo existente: Haz click en la base de datos sobre la ->, se seleccionara la direccion y la descripcion. Sus datos aparecerán en los campos de texto. Modifícalos y haz clic en 'Actualizar Datos'." & Environment.NewLine
        helpText &= "   - Para ELIMINAR un equipo: Selecciona el equipo en la tabla y haz clic en 'Eliminar Equipo'." & Environment.NewLine & Environment.NewLine

        helpText &= "2. Realizar Ping a Equipos:" & Environment.NewLine
        helpText &= "   - Haz clic en el botón 'Iniciar Ping'. El programa intentará comunicarse con cada equipo en tu lista." & Environment.NewLine
        helpText &= "   - Los resultados se mostrarán en la lista Derecha: '✅' si fue alcanzado, '❌' si no." & Environment.NewLine
        helpText &= "   - Al finalizar, un mensaje te informará si todos los equipos están encendidos o si no fueron alcanzados." & Environment.NewLine & Environment.NewLine

        helpText &= "3. Gestión de la Base de Datos:" & Environment.NewLine
        helpText &= "   - EXPORTAR Base de Datos: Guarda una copia de tu lista de equipos en un archivo '.db' en la ubicación que elijas. Útil para copias de seguridad." & Environment.NewLine
        helpText &= "   - IMPORTAR Base de Datos: Carga una lista de equipos desde un archivo '.db'. ¡CUIDADO! Esto reemplazará tu base de datos actual." & Environment.NewLine & Environment.NewLine

        helpText &= "¡Espero que te sea de gran utilidad!"

        MessageBox.Show(helpText, "Ayuda - Cómo Usar el Programa", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class

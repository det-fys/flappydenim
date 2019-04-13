Public Class frmMain
    Const v1 = "release"
    Const v2 = "1.2"

    Const verze = v1 + " " + v2
    '----------KONSTANTY-----------
    '> fyzika
    Dim gravitace = 1600
    Const vyskok = 450
    Dim rychlost = 200
    '> sloupy
    Const sloupSpodni = 400
    Const sloupHorni = 100
    Const sloupStredni = ((sloupSpodni + sloupHorni) / 2)

    Const sR = 40

    Const mezera As Integer = 150

    Const startVyska = 250
    Const startPozice = -550



    '----------DEKLARACE-----------
    Dim intermission As Boolean = True
    Dim gejmovr As Boolean = False
    Dim sila As Double = 0
    Dim vyska As Double = startVyska
    Dim pozice As Double = startPozice
    Dim skore = 0
    Dim casovac As Double = 0
    Dim cheatstr = "1234567890"

    Dim auto = False
    Dim nesmr = False
    Dim dflag = False
    Dim pause = False

    Dim dtText = ""
    Dim dtTime As Double = 0

    Dim cheated = False
    Dim textured = True
    Dim drawinfo = False

    Dim rectv = 520


    Const hsroot = "http://deadfish.zaridi.to/fd/"
    Dim hstext = ""
    Dim hs = False

    Public niknejm = ""

    Sub gameloop()
        On Error GoTo 7

        Dim tikStart = TikSec()
        Dim tikPosledni As Double
        Dim tikNyni As Double
        Dim rozdil As Double

        Dim avgFPS = -1

        tikPosledni = TikSec()
        tikNyni = TikSec()
        rozdil = 0

        Dim tbNebe = New TextureBrush(My.Resources.nebe, Drawing2D.WrapMode.Tile)

        While (Me.Visible)

            '------------------------------------------------------------
            '  VYTVORENI PRAZDNYHO BITMAPU 500x550 (500x600 pri DFINFO)
            '------------------------------------------------------------
            Dim vys = 550
            If drawinfo Then
                vys = 600
            End If

            Dim bmp As New Bitmap(500, vys)
            Dim bmpG = Graphics.FromImage(bmp)

            '-------- 
            '  NEBE
            '-------- 
            bmpG.Clear(ColorTranslator.FromOle(RGB(196, 255, 253)))
            If textured Then
                bmpG.FillRectangle(tbNebe, 0, 0, 500, 500)
            End If

            '--------- 
            '  DFLAG
            '--------- 
            If dflag Then
                For i = 1 To 1000
                    bmpG.FillRectangle(Brushes.White, 0, 0, 100, 100)
                Next
            End If

            '-------------------- 
            '  "CHEAT" VODOZNAK
            '--------------------
            If cheated Then
                Dim c = Color.FromArgb(70, 255, 255, 255)
                Dim b = New SolidBrush(c)
                Dim fnt = New Font("arial", 72, FontStyle.Bold)
                Dim strr = "CHEAT CHEAT CHEAT CHEAT"

                bmpG.DrawString(strr, fnt, b, -300, 10)
                bmpG.DrawString(strr, fnt, b, -200, 90)
                bmpG.DrawString(strr, fnt, b, -100, 170)
            End If

            '--------- 
            '  MARES
            '--------- 
            Dim avt = My.Resources.mares
            If gejmovr Or nesmr Then
                avt = My.Resources.maresblack
            End If
            avt.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Dim vyskakresleni As Integer = (500 - vyska - 20)
            bmpG.DrawImage(avt, 200, vyskakresleni, 40, 40)

            If Not intermission Then

                If Not pause Then

                    '---------- 
                    '  FYZIKA
                    '---------- 
                    sila += (gravitace * rozdil)
                    vyska += (-sila * rozdil)
                    If Not gejmovr Then
                        pozice += (rychlost * rozdil)
                    End If

                    '---------------------------------
                    '  GEJM OUVR PRI SPADNUTI NA ZEM
                    '---------------------------------
                    If vyska <= 0 Then
                        GameOver(skore)
                        intermission = True
                    End If

                End If
            End If

            '-----------------------------------
            '  KRESLENI SLOUPU, POCITANI SKORE
            '-----------------------------------
            skore = 0
            Dim test = Math.Round((pozice - 600) / 300)
            If test < 0 Then test = 0
            Dim naobrazovce = 0
            Do
                If PoziceSloupu(test) < (pozice + 200) Then
                    skore = test + 1 ' <-- SKORE
                End If

                If PoziceSloupu(test) > (pozice - 100) Then
                    If PoziceSloupu(test) > (pozice + 700) Then Exit Do
                End If

                naobrazovce = (PoziceSloupu(test) - pozice)
                Dim cv As Integer = VyskaSloupu(test)

                Dim horniOd As Integer = -rectv + (cv - (mezera / 2))
                Dim horniVyska As Integer = rectv
                Dim spodniOd As Integer = cv + (mezera / 2)
                Dim spodniVyska As Integer = rectv

                If textured Then
                    Dim tbsloup = New TextureBrush(My.Resources.blockEmerald40x40, Drawing2D.WrapMode.Tile)
                    tbsloup.TranslateTransform(naobrazovce, horniOd)
                    bmpG.FillRectangle(tbsloup, naobrazovce, horniOd, sR, horniVyska)
                    tbsloup = New TextureBrush(My.Resources.blockEmerald40x40, Drawing2D.WrapMode.Tile)
                    tbsloup.TranslateTransform(naobrazovce, spodniOd)
                    bmpG.FillRectangle(tbsloup, naobrazovce, spodniOd, sR, spodniVyska)
                Else
                    bmpG.FillRectangle(Brushes.LightGreen, naobrazovce, horniOd, sR, horniVyska)
                    bmpG.FillRectangle(Brushes.LightGreen, naobrazovce, spodniOd, sR, spodniVyska)
                End If

                ' OBRYS SLOUPU
                Dim obrys = New Pen(Color.Black, 2)
                bmpG.DrawRectangle(obrys, naobrazovce, horniOd, sR, horniVyska)
                bmpG.DrawRectangle(obrys, naobrazovce, spodniOd, sR, spodniVyska)

                '------------------------------------
                '  GEJM OUVR PRI NARAZENI DO SLOUPU
                '------------------------------------
                If Not nesmr Then
                    If (naobrazovce < (200 + 35)) And (naobrazovce > (200 - (0 + sR))) Then
                        If (vyskakresleni < (horniOd + rectv)) Or (vyskakresleni > (spodniOd - 40)) Then
                            GameOver(skore)
                        End If
                    End If
                End If

                If drawinfo Then bmpG.DrawString((naobrazovce - 200).ToString, New Font("courier new", 10, FontStyle.Bold), Brushes.Black, New Point(naobrazovce, 480))

                test += 1
            Loop

            '-------------
            '  BOT CHEAT
            '-------------
            If auto Then
                Dim sc = Math.Round((pozice + 310) / 300)
                If sc < 0 Then sc = 0
                'Debug.Print(sc)
                Dim v = (500 - (VyskaSloupu(sc)) - 40)
                If vyska < v Then
                    Weeeee()
                End If
            End If

            '--------------------
            '  DT (MODREJ TEXT)
            '--------------------
            If dtText <> "" Then
                If dtTime < 60 Then
                    dtTime -= rozdil
                End If

                Dim l = 60
                If gejmovr Then
                    l = 100
                End If

                centertext(bmpG, dtText, New Font("arial", 27, FontStyle.Bold), Brushes.DarkBlue, l)

                If dtTime < 0 Then
                    DTres()
                End If
            End If

            '--------------------------------
            '  KRESLENI SKORE A "GEJM OUVR"
            '--------------------------------
            If Not gejmovr Then
                centertext(bmpG, skore.ToString, New Font("arial", 40, FontStyle.Bold), Brushes.Black, 5)
            Else
                centertext(bmpG, "gejm ouvr", New Font("courier new", 40, FontStyle.Bold), Brushes.Red, 5)
                centertext(bmpG, "skore: " + skore.ToString, New Font("arial", 32, FontStyle.Bold), Brushes.Red, 50)
            End If

            '-------
            '  ZEM
            '-------
            If Not textured Then
                bmpG.FillRectangle(Brushes.Green, 0, 500, 600, 100)
            Else
                Dim tbSpodek = New TextureBrush(My.Resources.stone48x48, Drawing2D.WrapMode.Tile)
                tbSpodek.TranslateTransform(48 - (pozice Mod 48), 500)
                bmpG.FillRectangle(tbSpodek, 0, 500, 600, 100)
            End If

            '---------------------
            '  KLIK TU (RE)START
            '---------------------
            If intermission Then
                Dim restr = ""
                If gejmovr Then
                    restr = "RE"
                End If
                centertext(bmpG, UCase("KLIK Tů ") + restr + "STÁRT", New Font("arial", 36, FontStyle.Bold), Brushes.Black, 400)
            End If

            '--------------
            '  SCOREBOARD
            '--------------
            If hs Xor (intermission And Not gejmovr) Then
                Dim hs_psm As Font = New Font("Courier New", 11, FontStyle.Regular)

                Dim s As Size = TextRenderer.MeasureText(hstext, hs_psm)

                Dim hs_x As Integer = (500 - s.Width) / 2
                Dim hs_y As Integer = (500 - s.Height) / 2

                bmpG.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.White)), hs_x, hs_y, s.Width, s.Height)
                bmpG.DrawString(hstext, hs_psm, Brushes.Black, hs_x, hs_y)


            End If

            '---------------------
            '  KONTROLNI CASOVAC
            '---------------------
            casovac += rozdil

            '----------------
            '  INFO O VERZI
            '----------------
            bmpG.DrawString(verze, New Font("courier new", 10, FontStyle.Regular), Brushes.LightBlue, New Point(10, 521))

            '-----------------------
            '  DALSI INFO (DFINFO)
            '-----------------------
            If drawinfo Then
                bmpG.DrawString(("intermission: " + intermission.ToString + "     gameover: " + gejmovr.ToString), New Font("courier new", 10, FontStyle.Regular), Brushes.White, New Point(10, 534))
                bmpG.DrawString("(casovac) - (soucet zpozdeni) = " + (TikSec() - (casovac + tikStart)).ToString, New Font("courier new", 10, FontStyle.Regular), Brushes.White, New Point(10, 547))
                bmpG.DrawString("casovac  " + TikSec().ToString, New Font("courier new", 10, FontStyle.Regular), Brushes.White, New Point(10, 560))

            End If

            '----------------------------------
            '  POCITANI DOBY VYTVORENI SNIMKU
            '----------------------------------
            tikNyni = TikSec()
            rozdil = (tikNyni - tikPosledni) ' <-- DOBA VYTVORENI
            tikPosledni = tikNyni

            '-------
            '  FPS
            '-------
            Dim FPS = Math.Round(1 / rozdil)

            'Dim n = 70
            'avgFPS = ((((n - 1) * avgFPS) + FPS) / n)

            If drawinfo Then
                bmpG.DrawString(("FPS " + FPS.ToString + "| ~FPS " + avgFPS.ToString + " | zpozdeni " + rozdil.ToString), New Font("courier new", 10, FontStyle.Regular), Brushes.White, New Point(10, 573))
            Else
                bmpG.DrawString((" FPS " + FPS.ToString), New Font("courier new", 10, FontStyle.Regular), Brushes.White, New Point(150, 521))

            End If

            '--------------------
            '  ZOBRAZENI SNIMKU
            '--------------------
            pbHra.Image = bmp

            Application.DoEvents()
        End While

        Exit Sub

7:      MsgBox("  Tato shitska hra crashla: " + Err.Description, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "RIP")
        End
    End Sub


    '-----------------------
    '  POZICE/VYSKA SLOUPU
    '-----------------------
    Function PoziceSloupu(id As Integer)
        Return id * 300
    End Function
    Function VyskaSloupu(id As Integer)
        '123412341234
        '-^-_-^-_-^-_
        Dim v = id Mod 4
        Select Case (v + 1)
            Case 1 : Return sloupStredni
            Case 2 : Return sloupHorni
            Case 3 : Return sloupStredni
            Case 4 : Return sloupSpodni
        End Select
        Return 0
    End Function

    '---------------------
    '  RESET/ZACATEK HRY
    '---------------------
    Sub StartGame()
        If Not intermission Then
            Exit Sub
        End If
        gejmovr = False

        sila = 0
        vyska = startVyska
        pozice = startPozice
        intermission = False
    End Sub

    Sub GameOver(sk As Integer)
        If intermission Or gejmovr Then
            Exit Sub
        End If

        sila = 700
        gejmovr = True

        'SendScore(sk, "DF")

    End Sub

    '-----------------------
    '  VYSKOK PRI KLIKNUTI
    '-----------------------
    Sub Weeeee() Handles pbHra.MouseDown
        StartGame()
        If Not gejmovr Then
            sila = -vyskok
        End If
    End Sub

    Sub TikTak() Handles StartTimer.Tick
        Debug.Print("validated")
        StartTimer.Enabled = False
        gameloop()
    End Sub

    Function TikSec() As Double
        Return (Tik() / 10000000)
    End Function

    Function Tik() As Long
        Return Now.Ticks
    End Function

    '-----------------------
    '  TEXT NA STREDU OKNA
    '-----------------------
    Sub centertext(g As Graphics, text As String, psm As Font, br As Brush, y As Integer)
        Dim s = TextRenderer.MeasureText(text, psm).Width
        Dim x = 250 - (s / 2)
        g.DrawString(text, psm, br, x, y)
    End Sub


    '--------------------
    '  PRIKAZY / CHEATY
    '--------------------
    Sub cheaty(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        e.Handled = True

        cheatstr = (Strings.Right(cheatstr, 9) + UCase(e.KeyChar))
        If napravo(cheatstr, prikaz(0)) Then
            nesmr = Not nesmr
            If nesmr Then
                DT("NESMR ON", 1)
            Else
                DT("NESMR OFF", 1)
            End If

            cheated = True
        End If

        If napravo(cheatstr, prikaz(1)) Then
            auto = Not auto
            If auto Then
                DT("BOT ON!", 1)
            Else
                DT("BOT OFF!", 1)
            End If

            cheated = True
        End If

        If napravo(cheatstr, prikaz(2)) Then
            dflag = Not dflag
            If dflag Then
                DT("LAGGING", 1)
            Else
                DT("OK", 1)
            End If

            'cheated = True
        End If


        If napravo(cheatstr, prikaz(3)) Then
            textured = Not textured
            If textured Then
                DT("TEXTURY ON", 1)
            Else
                DT("TEXTURY OFF", 1)
            End If

            'cheated = True
        End If

        If napravo(cheatstr, prikaz(4)) Then
            drawinfo = Not drawinfo
            If drawinfo Then
                DT("DRAW_INFO ON", 1)
            Else
                DT("DRAW_INFO OFF", 1)
            End If

            'cheated = True
        End If

        If napravo(cheatstr, "DFP") Or napravo(cheatstr, " ") Then
            pause = Not pause
            If pause Then
                DT("PAUSED", 69)
            Else
                DT("RESUMED", 1)
            End If

            'cheated = True
        End If


        If napravo(cheatstr, prikaz(5)) Then
            DT("DYS IS FAKIN TEST", 1)
        End If

        If napravo(cheatstr, prikaz(6)) Then
            DT("© DeadFish - 2019", 3)
        End If

        If napravo(cheatstr, prikaz(7)) Then

            pozice = (300 * 6900000) - 400
            DT("WEEEEEEEE!", 1)

            cheated = True
        End If

        If napravo(cheatstr, prikaz(8) + "+") Then
            rychlost += 50
            DT("SPÝD: " + rychlost.ToString, 1)
            cheated = True
        End If

        If napravo(cheatstr, prikaz(8) + "-") Then
            rychlost -= 50
            DT("SPÝD: " + rychlost.ToString, 1)
            cheated = True
        End If

        If napravo(cheatstr, prikaz(9) + "+") Then
            gravitace += 200
            DT("GRAVITACE: " + gravitace.ToString, 1)
            cheated = True
        End If

        If napravo(cheatstr, prikaz(9) + "-") Then
            gravitace -= 200
            DT("GRAVITACE: " + gravitace.ToString, 1)
            cheated = True
        End If

        If napravo(cheatstr, prikaz(10)) Then
            cheated = False
        End If

        If napravo(cheatstr, prikaz(11)) Then
            gravitace = 1600
            rychlost = 200
            auto = False
            nesmr = False
            dflag = False
            pozice = startPozice
            DT("DEFAULT", 1)
            cheated = False
        End If
    End Sub

    Sub DT(text As String, cas As Double)
        dtText = text
        dtTime = cas
    End Sub

    Sub DTres()
        dtText = ""
        dtTime = 0
    End Sub

    Function napravo(zdroj As String, co As String) As Boolean
        Return (Strings.Right(zdroj, co.Length) = co)
    End Function




End Class

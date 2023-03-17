<h2>💾 Como utilizar</h2>

1 - Inicialmente, clone o projeto:
<code>git clone git@github.com:theoxDEV/Sydy.Teste.git</code>

<p>Depois rode o projeto em alguma IDE (preferencialmente Visual Studio 2022).</p>

2 - Para utilizar o SQL Server local, você deve substituir o valor da chave <i>ConnectionString</i> localizada em <b>SydyTest.API > appsettings.Development.json</b> pela sua chave ConnectionString (Ex. <code>"Server=MEU_SERVIDOR\\SQLEXPRESS;Database=MEU_BANCO_DE_DADOS;Trusted_Connection=True;TrustServerCertificate=true;"</code>)

3 - Ainda no Visual Studio abra o Console do Gerenciador de Pacotes (<b>Ferramentas > Gerenciador de Pacotes do NuGet > Console do Gerenciador de Pacotes</b>)

4 - No console digite o seguinte comando <code>dotnet ef database update  --verbose --project SydyTeste.Data --startup-project SydyTeste</code> (O projeto padrão DEVERÁ ser SydyTeste.API)

5 - O último passo é o Build do projeto.

<h2>👨‍💻 Tecnologias</h2>

<ul>
<li>.NET 7</li>
<li>EntityFramework Core v7.0.4</li>
<li>SQL Server</li>
<li>Visual Studio 2022</li>
</ul>

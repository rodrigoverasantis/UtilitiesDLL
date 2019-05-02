using System;
using System.Collections.Generic;

namespace UtilitiesDLL {
  public class DataGeneration {

    #region CONSTANTES
    private const int RUN_RUT_MINIMO = 1000000;//Run y Rut mínimo posible 1.000.000
    private const int RUN_RUT_MAXIMO = 99999999;//Run y Rut máximo posible 99.999.999

    private const int RUN_MAXIMO = 40000000;//Run máximo posible 40.000.000
    private const int RUT_MINIMO = 60000000;//Rut mínimo posible 60.000.000

    private const int EDAD_MINIMA = 1;//Edad mínima posible 1 año
    private const int EDAD_MAXIMA = 130;//Edad máxima posible 130 años

    private const int TELEFONO_MINIMO = 30000000;//Número telefónico mínimo posible 30000000
    private const int TELEFONO_MAXIMO = 99999999;//Número telefónico máximo posible 99999999
    #endregion

    /// <summary>
    /// Método encargado de retornar el digito verificador de un RUN o RUT.
    /// </summary>
    /// <param name="_input">/número de RUN o RUT al cual se le calculará el dígito verificador</param>
    /// <exception cref="ArgumentException">Se genera en caso de enviar un RUN o RUT no válido (menor a 1.000.000 o mayor a 99.999.999)</exception>
    /// <exception cref="Exception.Exception(string, Exception)">Se genera en caso de fallar la ejecución del método</exception>
    /// <returns></returns>
    public string DigitoVerificador(int _input) {
      try {
        if (_input < DataGeneration.RUN_RUT_MINIMO || _input > DataGeneration.RUN_RUT_MAXIMO) {
          throw new ArgumentException("Error, RUN o RUT no válido.");
        }
        string dvEsperado = string.Empty;
        int suma = 0;
        int multiplicador = 1;
        while (_input != 0) {
          multiplicador++;
          if (multiplicador == 8) {
            multiplicador = 2;
          }
          suma += (_input % 10) * multiplicador;
          _input = _input / 10;
        }
        suma = 11 - (suma % 11);
        if (suma == 11) {
          dvEsperado = "0";
        } else if (suma == 10) {
          dvEsperado = "K";
        } else {
          dvEsperado = suma.ToString();
        }
        return dvEsperado;
      } catch (Exception e) {
        throw new Exception("Error al intentar calcular el dígito verificador del RUN o RUT ingresado.",e);
      }
    }

    /// <summary>
    /// Método encargado de generar un RUN o RUT aleatorio, entre los límites enviados.
    /// </summary>
    /// <param name="_limiteInferior">Límite inferior del RUN o RUT que será generado</param>
    /// <param name="_limiteSuperior">Límite superior del RUN o RUT que será generado</param>
    /// <exception cref="Exception.Exception(string, Exception)">Se genera en caso de fallar la ejecución del método</exception>
    /// <returns></returns>
    private string RandomRunRut(int _limiteInferior,int _limiteSuperior) {
      try {
        var randomRun = new Random().Next(_limiteInferior,_limiteSuperior);
        var dv = this.DigitoVerificador(randomRun);
        return $"{randomRun}-{dv}";
      } catch (Exception e) {
        throw new Exception("Error al intentar generar un RUN o RUT.",e); ;
      }
    }

    /// <summary>
    /// Método encargado de generar un RUN con dígito verificador de manera aleatoria, entre 1.000.000 y 40.000.000.
    /// </summary>
    /// <exception cref="Exception.Exception(string, Exception)">Se genera en caso de fallar la ejecución del método</exception>
    /// <returns></returns>
    public string RandomRun() {
      try {
        var runRut = this.RandomRunRut(DataGeneration.RUN_RUT_MINIMO,DataGeneration.RUN_MAXIMO);
        return runRut;
      } catch (Exception e) {
        throw new Exception("Error al intentar generar un RUN aleatorio.",e);
      }
    }

    /// <summary>
    /// Método encargado de generar un RUN con dígito verificador de manera aleatoria, entre los límites enviados.
    /// Los límites de un RUN son 1.000.000 y 40.000.000.
    /// </summary>
    /// <param name="_limiteInferior">Límite inferior del RUN que será generado</param>
    /// <param name="_limiteSuperior">Límite superior del RUT que será generado</param>
    /// <exception cref="ArgumentException">Se genera en caso de enviar límites fuera de rango o no válidos</exception>
    /// <exception cref="Exception.Exception(string, Exception)">Se genera en caso de fallar la ejecución del método</exception>
    /// <returns></returns>
    public string RandomRun(int _limiteInferior,int _limiteSuperior) {
      try {
        if (_limiteInferior < DataGeneration.RUN_RUT_MINIMO || _limiteSuperior > DataGeneration.RUN_MAXIMO) {
          throw new ArgumentException("Límites del RUN fuera de rango.");
        }
        if (_limiteInferior > _limiteSuperior) {
          throw new ArgumentException("Límites del RUN no válidos.");
        }
        var run = this.RandomRunRut(_limiteInferior,_limiteSuperior);
        return run;
      } catch (Exception e) {
        throw new Exception("Error al intentar generar un RUN aleatorio.",e);
      }
    }

    /// <summary>
    /// Método encargado de generar un RUT con dígito verificador de manera aleatoria, entre 60.000.000 y 99.999.999.
    /// </summary>
    /// <exception cref="Exception.Exception(string, Exception)">Se genera en caso de fallar la ejecución del método</exception>
    /// <returns></returns>
    public string RandomRut() {
      try {
        var rut = this.RandomRunRut(DataGeneration.RUT_MINIMO,DataGeneration.RUN_RUT_MAXIMO);
        return rut;
      } catch (Exception e) {
        throw new Exception("Error al intentar generar un RUT aleatorio.",e);
      }
    }

    /// <summary>
    /// Método encargado de generar un RUT con dígito verificador de manera aleatoria, entre los límites enviados.
    /// </summary>
    /// <param name="_limiteInferior">Límite inferior del RUT que será generado</param>
    /// <param name="_limiteSuperior">Límite superior del RUT que será generado</param>
    /// <exception cref="ArgumentException">Se genera en caso de enviar límites fuera de rango o no válidos</exception>
    /// <exception cref="Exception.Exception(string, Exception)">Se genera en caso de fallar la ejecución del método</exception>
    /// <returns></returns>
    public string RandomRut(int _limiteInferior,int _limiteSuperior) {
      try {
        if (_limiteInferior < DataGeneration.RUT_MINIMO || _limiteSuperior > DataGeneration.RUN_RUT_MAXIMO) {
          throw new ArgumentException("Límites del RUT fuera de rango.");
        }
        if (_limiteInferior > _limiteSuperior) {
          throw new ArgumentException("Límites del RUT no válidos.");
        }
        var rut = this.RandomRunRut(_limiteInferior,_limiteSuperior);
        return rut;
      } catch (Exception e) {
        throw new Exception("Error al intentar generar un RUT aleatorio.",e);
      }
    }

    /// <summary>
    /// Método encargado de generar un nombre de manera aleatoria.
    /// </summary>
    /// <exception cref="Exception.Exception(string, Exception)">Se genera en caso de fallar la ejecución del método</exception>
    /// <returns></returns>
    public string RandomNombre() {
      try {
        var listaNombres = new List<string> { "Aarón","Ander","Joaquín","Abel","Andrés","Joel","Abelardo","Ángel","Jon","Abraham","Aníbal","Jordi","Adalberto","Antonio","Jorge","Adam","Arnau","José","Adán","Arturo","Jose","Antonio","Adiran","Asier","Jose","Luis","Adolfo","Augusto","Jose","Manuel","Adrià","Aurelio","Jose","Maria","Adrián","Baltasar","Juan","Agustín","Bartolomé","Blas","Aimar","Basilio","Juan","Antonio","Aitor","Benito","Boris","Alano","Benjamín","Juan","Carlos","Alberto","Bernardo","Borja","Aldo","Bienvenido","Brahim","Aleix","Blas","Brais","Alejandro","Boris","Bruno","Alejo","Borja","Calisto","Alex","Brahim","Juan","José","Alfonso","Brais","Camilo","Alfredo","Bruno","Juan","Manuel","Alonso","Calisto","Carlos","Álvaro","Camilo","Julio","Amadeo","Carlos","Cayetano","Amado","Cayetano","César","Amando","César","Christian","Ambrosio","Christian","Claudio","Amin","Claudio","Clemente","Anastasio","Clemente","Conrado","Ander","Conrado","Constantino","Constantino","Francisco","Javier","Joel","Crispín","Francisco","José","Jon","Cristian","Gabriel","Jordi","Daniel","Gaspar","Jorge","Darío","Gerard","José","David","Gerardo","Jose","Antonio","Desiderio","Germán","Jose","Luis","Diego","Gonzalo","Jose","Manuel","Dionisio","Gregorio","Jose","Maria","Domingo","Guillem","Juan","Donato","Guillermo","Juan","Antonio","Edgar","Gustavo","Juan","Carlos","Edmundo","Hamza","Juan","José","Eduardo","Héctor","Juan","Manuel","Elías","Honorato","Julio","Eloy","Hugo","Justino","Emilio","Humberto","Justo","Eneko","Ibai","Kevin","Enrique","Ibrahim","Kilian","Eric","Ignacio","Leo","Ernesto","Iker","Leopoldo","Esteban","Isidoro","Lorenzo","Eugenio","Ismael","Louis","Eusebio","Ivo","Lucas","Fabián","Izan","Luciano","Federico","Jaime","Luis","Felipe","Jan","Macario","Félix","Jaume","Manuel","Fermín","Javier","Marc","Fernando","Jesús","Marcelo","Fidel","Joan","Marco","Francisco","Joaquín","Marcos","Marcos","Pau","Tomás","Mariano","Pedro","Ulises","Mario","Pelayo","Unai","Marti","Plácido","Urbano","Martín","Platón","Valentín","Mateo","Pol","Vicente","Matías","Ponce","Víctor","Mauricio","Quintín","Virgilio","Maximiliano","Rafael","Walter","Máximo","Ramiro","Wen","Miguel","Ramón","Xabier","Miguel","Ángel","Raúl","Xavier","Mikel","Ricardo","Ximen","Mohamed","Roberto","Yerai","Moisés","Rodrigo","Yeray","Nabil","Rogelio","Yunes","Narciso","Román","Yusef","Nathan","Rubén","Zacarías","Nicolás","Salvador","Zenon","Noé","Samuel","Zoilo","Octavio","Santiago","Oier","Sebastián","Omar","Sergi","Oriol","Sergio","Óscar","Silvestre","Pablo","Simón","Pancho","Teodoro" };
        var posicion = new Random().Next(0,listaNombres.Count - 1);
        return listaNombres[posicion];
      } catch (Exception e) {
        throw new Exception("Error al intentar generar un nombre aleatorio.",e);
      }
    }

    /// <summary>
    /// Método encargado de generar un apellido de manera aleatoria.
    /// </summary>
    /// <returns></returns>
    public string RandomApellido() {
      try {
        var listaApellidos = new List<string> { "Abad","Abadía","Abarca","Abastos","Abaunza","Abbot","Abdallá","Abdalah","Abdallah","Abdelnour","Abdo","Abea","Abel","Abela","Abelado","Abella","Abellán","Abendaño","Abou","Abraham","Abrahams","Abrahán","Abrego","Abreu","Abrigo","Abril","Abufelo","Abugadba","Aburto","Acabal","Acebal","Acedo","Acevedo","Acosta","Acuña","Adames","Adamis","Adanaque","Adanis","Adis","Aedo","Agababa","Agámez","Agayón","Agrazal","Agreda","Aguayo","Agudelo","Agüero","Aguiar","Aguilar","Aguilera","Aguiluz","Aguilve","Aguinaga","Aguirre","Agurto","Agustín","Ahuja","Ahumada","Aiello","Aiza","Aizprúa","Aizpurúa","Alache","Alama","Alan","Alani","Alanis","Alanís","Alaniz","Alarcón","Alas","Alavez","Alayón","Alba","Albarello","Albarracín","Albelo","Albenda","Alburola","Alcaíno","Alcanzar","Alcázar","Alcazar","Alcibar","Alcócer","Alcóser","Alcóver","Alcózer","Aldana","Aldaña","Aldapa","Aldecoba","Alderrama","Alegría","Alejos","Alemán","Alexander","Alexandre","Alfaro","Alfonso","Algaba","Alguera","Aliaga","Alicama","Alier","Alizaga","Allan","Allon","Alluín","Almanza","Almanzar","Almanzo","Almaraz","Almazan","Almeida","Almendares","Almendárez","Almendáriz","Almengor","Almonte","Aloisio","Aloma","Alomar","Alonso","Alonzo","Alpírez","Alpízar","Altamirano","Altenor","Alterno","Altino","Altonor","Alva","Alvarado","Alvarenga","Alvares","Álvarez","Alvaro","Alvear","Alverde","Alvergue","Alvir","Alzate","Amado","Amador","Amalla","Amaris","Amaya","Amor","Amora","Amores","Amoros","Ampie","Ampié","Ampiée","Ampiee","Anaya","Anchetta","Anchez","Anchía","Anchieta","Andia","Andino","Andrade","André","Andrés","Andujar","Andújar","Andujo","Angele","Angelini","Anglada","Angulo","Anice","Anjos","Ansorena","Antelo","Antero","Antezana","Antich","Antillón","Antón","Antúnez","Anzora","Aparicio","Apolinar","Apollonio","Aponte","Aquiles","Aquino","Aragón","Aragones","Aragonés","Araica","Arana","Arancibia","Aranda","Arando","Arango","Aranjo","Araque","Arata","Araujo","Araus","Arauz","Araya","Arbaiza","Arballo","Arbelo","Arbizu","Arbizú","Arboleda","Arburola","Arca","Arcarate","Arce","Arceyudh","Arceyut","Arceyuth","Arcia","Arcía","Arciniegas","Ardila","Ardín","Ardón","Ardonnix","Areas","Arellano","Arena","Arenas","Arévalo","Argudo","Arguedas","Argüelles","Argüello","Argueta","Arguijo","Arias","Ariasdes","Arica","Arie","Ariño","Arispe","Arista","Ariza","Arjona","Armada","Armas","Armenta","Armento","Armeras","Armesto","Armijo","Arnáez","Arnau","Arnesto","Anuelo","Arnuero","Arone","Arosemena","Arquín","Arrazola","Arrea","Arredondo","Arreola","Arriaga","Arriagada","Arrieta","Arriola","Arrocha","Arroliga","Arrollo","Arrone","Arrones","Arronés","Arronez","Arronis","Arroniz","Arroyave","Arroyo","Arrubla","Artavia","Arteaga","Artecona","Artiaga","Artiga","Artiles","Artiñano","Artola","Artolozaga","Aruj","Aruizu","Arze","Arzola","Ascante","Ascencio","Asch","Asencio","Asero","Así","Asís","Aspirita","Astacio","Astete","Astorga","Astorquiza","Astúa","Asturias","Asunción","Asusema","Atehortúa","Atein","Atencio","Atensio","Atiensa","Atienza","Augusto","Ávalos","Avelar","Avellán","Avendaño","Ávila","Avilés","Avilez","Ayala","Ayales","Ayara","Ayarza","Aybar","Aycinena","Ayerdis","Aymerich","Azar","Azaria","Asofeifa","Azqueta","Azua","Azúa","Azuar","Azucena","Azul","Azuola","AzurdiaBabb","Babar","Baca","Bacca","Bacigalupo","Badilla","Bado","Báez","Baeza","Baidal","Bairnales","Baizan","Bajarano","Balarezo","Baldares","Balday","Baldelomar","Balderas","Balderrama","Balderramos","Baldí","Baldi","Baldioceda","Baldivia","Baldizón","Balladares","Ballar","Ballard","Ballester","Ballestero","Ballesteros","Ballón","Balma","Balmaceda","Balmacera","Balon","Balser","Baltodano","Banegas","Banet","Banilla","Baños","Bañuelos","Baquedano","Baquero","Baradín","Baraen","Barahoma","Barahona","Barajas","Baraquiso","Barat","Barba","Barbagallo","Barbagebra","Bárbara","Barbena","Barben","Barberena","Barbosa","Barboza","Barcelas","Barcelata","Barcenas","Barcia","Bardayan","Barguil","Barillas","Barletta","Baro","Barón","Barquedano","Barquero","Barquette","Barra","Barracosa","Barrante","Barrantes","Barraza","Barreda","Barrenechea","Barrera","Barrero","Barreto","Barrias","Barrientos","Barriga","Barrio","Barrionuevo","Barrios","Barroso","Barrot","Barrott","Barrundia","Barsallo","Bart","Bartal","Barteles","Bartels","Barth","Barvas","Baruch","Basadre","Basán","Basilio","Basti","Bastida","Bastos","Bastti","Batalla","Batán","Batista","Batres","Bautista","Bauzid","Baviera","Bayo","Bazán","Bazo","Beatriz","Becancur","Becerra","Becerril","Bedolla","Bedoya","Beeche","Beeché","Beingolea","Beita","Bejarano","Bejos","Bel","Belette","Belgrave","Bellanero","Bellido","Bello","Belloso","Belmonte","Beltrán","Beltre","Benach","Benambourg","Benambugr","Benambur","Benavente","Benavides","Benavídez","Benda","Bendaña","Bendig","Bendij","Benedictis","Beneditt","Benevides","Bengoechea","Benites","Benítez","Benito","Benzón","Berasaluce","Berciano","Berdasco","Berdugo","Berenzón","Bermejo","Bermeo","Bermudes","Bermúdez","Bernadas","Bernal","Bernardo","Bernat","Berrios","Berríos","Berrocal","Berrón","Bertel","Bertrán","Betancort","Bentancourt","Betancourth","Betancur","Betancurt","Beter","Beteta","Bethancourt","Betrano","Better","Biamonte","Binda","Blanco","Blandino","Blando","Blandón","Blau","Blum","Bobadilla","Bodán","Bogán","Bogantes","Bogarín","Bohorguez","Bohorquez","Bojorge","Bolaños","Bolívar","Bonice","Boniche","Bonichi","Bonilla","Borbas","Borbón","Borda","Bordallo","Borge","Borges","Borja","Borjas","Borjes","Borloz","Borras","Borrasé","Borredo","Borrero","Bosque","Botero","Boza","Bran","Bravia","Bravo","Brenes","Breve","Briceño","Brilla","Briones","Brito","Brizeño","Brizuela","Buencamino","Buendía","Bueno","Bueso","Buezo","Buga","Bugarín","Bugat","Bugria","Burgos","Burguera","Burgues","Burillo","Busano","Bustamante","Bustillo","Bustillos","Busto","Bustos","Buzano","Buzeta","BuzoCaamano","Caamaño","Cabada","Cabadianes","Cabal","Cabalceta","Caballero","Cabana","Cabaña","Cabeza","Cabezas","Cabistán","Cabral","Cabrera","Cabrerizo","Cáceres","Cadenas","Cadet","Cageao","Caicedo","Cairol","Cajas","Cajiao","Cajina","Cala","Calatayud","Calazán","Calcáneo","Caldas","Caldera","Calderón","Calero","Caliva","Calix","Calle","Calleja","Callejas","Callejo","Calles","Calvo","Calzada","Camacho","Camaño","Camarena","Camareno","Camarillo","Cambronero","Camona","Campabadal","Campabadall","Campodónico","Campos","Canales","Canalias","Canas","Candamo","Candelaria","Candelario","Canejo","Canessa","Canet","Canetta","Canizales","Canizález","Canizares","Canno","Cano","Canossa","Cantarero","Cantero","Cantillano","Canto","Cantón","Cañas","Cañizales","Cañizález","Capón","Carabaguias","Carabaguiaz","Caranza","Caravaca","Carazo","Carbalda","Carballo","Carbonell","Carbonero","Carcache","Carcachi","Cárcamo","Carcedo","Carcía","Cárdenas","Cárdenes","Cardona","Cardos","Cardoso","Cardoza","Cardoze","Cares","Carias","Caridad","Carit","Carlos","Carmiol","Carmona","Carnero","Caro","Carpio","Carranza","Carrasco","Carrasquilla","Carreño","Carrera","Carreras","Carrillo","Carrión","Carrizo","Carro","Cartagena","Cartago","Cartín","Carvajal","Carvalho","Carvallo","Casa","Casaca","Casafont","Casal","Casanova","Casañas","Cásares","Casas","Casasnovas","Casasola","Cascante","Casco","Casorla","Cassasola","Cásseres","Castaneda","Castañeda","Castañedas","Castaño","Castañón","Castaños","Castelán","Castellano","Castellanos","Castellón","Casteñeda","Castiblanco","Castilla","Castillo","Castro","Catania","Cateres","Catón","Cavalceta","Cavaller","Cavallo","Cavanillas","Cavazos","Cavero","Cazanga","Ceba","Ceballos","Ceciliano","Cedeño","Cejudo","Celada","Celedón","Celís","Centella","Centeno","Cepeda","Cerceño","Cerda","Cerdas","Cerna","Cernas","Cerón","Cerpas","Cerros","Cervantes","Cervilla","Céspedes","Cevallos","Cevedo","Cevilla","Chabrol","Chacón","Chamarro","Chamorro","Chanquín","Chanta","Chanto","Chavarría","Chavera","Chaverri","Chaves","Chávez","Chavira","Cheves","Chévez","Chica","Chicaiza","Chicas","Chilquillo","Chinchilla","Chinchillo","Chirino","Chirinos","Chocano","Choza","Cid","Cifuentes","Cintrón","Cisar","Cisne","Cisnero","Cisneros","Cisternas","Claro","Cleves","Cobaleda","Coe","Coello","Coen","Cohen","Coles","Colina","Colindres","Collado","Collina","Colom","Coloma","Colombo","Colomer","Concepción","Concha","Conde","Condega","Condes","Conedo","Conejo","Congosto","Conte","Contreras","Corales","Corao","Cordeiro","Cordero","Cordido","Córdoba","Cordón","Cordonero","Córdova","Cordoze","Corea","Corella","Cornavaca","Cornejo","Corona","Coronado","Coronas","Coronel","Corrales","Correa","Corredera","Corro","Corta","Cortaberría","Cortés","Cortez","Cortinez","Cortissoz","Corvera","Cosio","Cosiol","Cosme","Cossio","Costa","Cotera","Coto","Crespo","Crispín","Crispino","Cruces","Cruz","Cuadra","Cuadrado","Cuan","Cuaresma","Cuarezma","Cuarta","Cubas","Cubenas","Cubero","Cubías","Cubias","Cubilla","Cubillo","Cubillos","Cubria","Cuebas","Cuellar","Cuéllar","Cuello","Cuenca","Cuendis","Cuernavaca","Cuervo","Cuesta","Cueva","Cuevas","Cuevillas","Cunill","Cunillera","Curbelo","Curco","CurdeloDaCosta","DaSilva","Dacosta","D’Acosta","Dalorso","Dalorzo","Dalsaso","Damaceno","Damito","Daniel","Daniels","Dapuerto","Dapueto","Darce","Darche","Darcia","Darío","Dasadre","Dasilva","Dávalos","David","Dávila","Davis","D’Avola","DeAbate","DeAguilar","DeAlba","DeAlvarado","DeBenedictis","DeBriones","DeCamino","DeCastro","DeCéspedes","DeEspeleta","DeEzpeleta","DeFalco","DeFaria","DeFranco","DeJesús","DeJorge","DeJuana","DeLaCruz","DeLaCuesta","DeLaEspriella","DeLaFuente","DeLaGarza","DeLaGuardia","DeLaHerran","DeLaHormaza","DeLaJara","DeLaMata","DeLaNuez","DeLaO","DeLaOsa","DeLaOssa","DeLaPaz","DeLaPeña","DeLaRocha","DeLaRosa","DeLaSelva","DeLaTeja","DeLaTorre","DeLaTrava","DeLaVega","DeLargaespada","DeLasCasas","DeLasCuevas","DeLasHeras","DeLemos","DeLeón","DeLev","DeLima","DeLópez","DeLuz","DeMiguel","DeMiranda","DeMoya","DeOdio","DeÓleo","DeOna","DeOña","DePaco","DeParedes","DePass","DePaz","DePazos","DePedro","DePinedo","DePrado","DeRayo","DeSárraga","DeSá","DeTrinidad","DeUreña","DeVega","DeYglesias","DelBarco","DelBarrio","DelBello","DelBusto","DelCarmen","DelCastillo","DelCid","DelPilar","DelPimo","DelRío","DelRisco","DelSocorro","DelSolar","DelValle","Delatolla","Delgadillo","Delgado","Deliyore","Dellale","Dellanoce","Delso","Delvo","Dengo","Denis","Dennis","Detrinidad","Devanda","Devandas","Devoto","Dias","Díaz","Díez","Díjeres","Díjerez","Dimas","Dinares","Dinarte","Discua","Doblado","Dobles","Dodero","Dalmus","Dalmuz","Domingo","Domínguez","Donado","Donaire","Donato","Doña","Doñas","Donzón","Dorado","Dormos","Dormuz","Doryan","Duar","Duares","Duarte","Duartes","Duenas","Dueñas","Duque","DuqueEstrada","Durall","Durán","Durante","Duval","Duvall","DuverránEchandi","Echavarría","Echeverri","Echeverría","Eduarte","Egea","Elías","Eligia","Elizalde","Elizonda","Elizondo","Elmaleh","Emanuel","Enrique","Enriques","Enríquez","Eras","Erazo","Escabar","Escalante","Escamilla","Escarré","Escobar","Escobedo","Escocia","Escorriola","Escosia","Escoto","Escovar","Escribano","Escude","Escudero","España","Esparragó","Espelerta","Espeleta","Espinach","Espinal","Espinales","Espinar","Espino","Espinosa","Espinoza","Espitia","Esquivel","Esteban","Esteves","Estévez","Estrada","EstrellaFaba","Fabara","Fabián","Fábrega","Fabregat","Fabres","Facio","Faerrón","Faeth","Faiges","Fait","Faith","Fajardo","Falco","Falcón","Falla","Fallas","Farach","Farah","Fargas","Farias","Farías","Faries","Fariña","Fariñas","Farrach","Farrer","Farrera","Farrier","Fatjo","Fatjó","Faundez","Faune","Fava","Fazio","Fermández","Fermán","Fernandes","Fernández","Fernando","Ferrada","Ferrán","Ferrando","Ferraro","Ferreira","Ferreiro","Ferrer","Ferrero","Ferris","Ferro","Ferros","Fiallos","Fictoria","Fidalgo","Fierro","Figueiredo","Figuer","Figueras","Figueres","Figueroa","Filomena","Fletes","Fletis","Flores","Fonseca","Font","Forero","Formoso","Fornaguera","Fraga","Fraguela","Francés","Frances","Francesa","Francia","Francis","Franco","Fray","Frayle","Freer","Freira","Fresno","Freyre","Frías","Frutos","Fuentes","Fumero","Funes","Funez","Fúnez","Fuscaldo","FuscoGabriel","Gadea","Gaete","Gago","Gainza","Gaitán","Galacia","Galagarza","Galán","Galarza","Galaviz","Galba","Galcerán","Galeano","Galeas","Galeno","Galera","Galiana","Galiano","Galindo","Galino","Galiñanes","Gallardo","Gallegas","Gallegos","Gallo","Galo","Galtés","Galván","Gálvez","Galvis","Gamarra","Gamazo","Gambo","Gamboa","Gámez","Garay","Garayar","Garbanzo","Garcés","García","Gardela","Gargollo","Garino","Garita","Garmendia","Garner","Garnier","Garreta","Garrido","Garro","Garrón","Garza","Garzel","Garzón","Garzona","Gaspar","Gateno","Gateño","Gavarrete","Gavilán","Gaviria","Gavosto","Gayoso","Gaytán","Gazel","Gazo","Geoyenaga","Gil","Gillén","Gilles","Giral","Giraldo","Giraldt","Giralt","Giro","Girón","Gladis","Goches","Góchez","Godines","Godínez","Godoy","Goic","Goicoechea","Goicuria","Goldenberg","Golfín","Gomar","Gómez","Gomis","Gondres","Góndrez","Góngora","Gonzaga","Gonzales","González","Gonzalo","Goñi","Gordon","Górgona","Goyenaga","Gracía","Gracias","Gradis","Grajal","Grajales","Grajeda","Grana","Granada","Granados","Granda","Grandoso","Granera","Granizo","Granja","Graña","Gras","Grau","Greco","Greñas","Gridalva","Grigoyen","Grijalba","Grijalda","Grijalva","Grillo","Guadamuz","Guadrón","Guajardo","Guardado","Guardano","Guardia","Guardián","Guardiola","Guarín","Guasch","Gudino","Gudiño","Güel","Güell","Güendel","Güendell","Guerra","Guerrero","Guevara","Guido","Guie","Guier","Guifarro","Guilá","Guillarte","Guillén","Guillermet","Guillermo","Guilles","Güillies","Guillies","Guillis","Guilloch","Guiménez","Guindos","Guitiérrez","Guitta","Guix","Gulubay","Gunera","Guntanis","Gurdián","Gurrero","Gurrola","Gustavino","Gutiérrez","GuzmánHaba","Habibe","Haenz","Harrah","Hénchoz","Henríquez","Henrriquez","Herdocia","Heredia","Herencia","Heríquez","Hermann","Hermosilla","Hernández","Hernando","Hernánez","Herra","Herradora","Herrán","Herrera","Herrero","Hevia","Hidalgo","Hierro","Hincapié","Hinostroza","Horna","Hornedo","Huerta","Huertas","Huete","Huezo","Hurtado","HurtechoIbáñez","Ibarra","Ibarras","Icaza","Iglesias","Ilama","Incapié","Incer","Incera","Inceras","Inces","Infante","Iracheta","Iraheta","Irastorza","Irias","Iribar","Irigaray","Irola","Isaac","Isaacs","Israel","Ivañez","Izaba","Izaguirre","Izandra","Iznardo","Izquierdo","Izrael","IzurietaJácamo","Jacobo","Jácome","Jácomo","Jaen","Jáenz","Jara","Jaramillo","Jarquín","Jarrín","Jerano","Jerez","Jiménez","Jimera","Jinesta","Jirón","Joseph","Jovel","Juárez","Junco","Juncos","JuradoKaminsky","Klein","KuadraLaBarca","Labra","Lacarez","Lacayo","Lafuente","Lago","Lagos","Laguardia","Laguna","Lain","Laine","Lainez","Laitano","Lamas","Lamela","Lamicq","Lamugue","Lamuza","Lancho","Lanco","Landazuri","Lández","Lanuza","Lanza","Lanzas","Lapeira","Laporte","Laprade","Lara","Lares","Largaespada","Largo","Larios","Larrabure","Larrad","Larragan","Larragán","Larraguivel","Lasa","Lasantas","Láscares","Láscarez","Láscaris","Lasso","Lastra","Lastreto","Latiff","Latino","Latorraca","Laurito","Laverde","Lázaro","Lázarus","Lázcares","Lazo","Lazzo","L’Calleja","Leal","Leandra","Leandro","Ledezma","Ledo","Leitón","Leiva","Lejarza","Lemmes","Lemos","Lemus","Lemuz","Leñero","León","Lépiz","Levi","Leytón","Leyva","Lezama","Lezana","Lezcano","Lhamas","Lieberman","Lima","Linares","Linarte","Lindo","Lines","Líos","Lira","Lizama","Lizana","Lizano","Lizarme","Llabona","Llach","Llado","Llamazares","Llamosas","Llano","Lanos","Llanten","Llaurado","Llerena","Llibre","Llinas","Llobet","Llobeth","Llorca","Llorella","Llorens","Llorente","Llosent","Lloser","Llovera","Llubere","Loáciga","Loáiciga","Loáisiga","Loaissa","Loaiza","Lobo","Loeb","Loew","Loinaz","Lombardo","Londoño","Lope","Lopes","Lopera","López","Lopezlage","Loprete","Lora","Loredo","Lorente","Lorenz","Lorenzana","Lorenzen","Lorenzo","Loría","Lorío","Lorio","Lorz","Losada","Losilla","Louk","Louzao","Loynaz","Loza","Lozano","Luarca","Lucas","Lucena","Lucero","Lucke","Lugo","Luis","Luján","Luna","Lunaza","Luque","LuquezMacaya","Macedo","Maceo","Machado","Machín","Machuca","Macia","Macias","Macías","Macís","Macre","Macrea","Madariaga","Maderos","Madinagoitia","Madrano","Madrid","Madriga","Madrigal","Madril","Madriz","Maduro","Magalhaes","Magallón","Magaña","Magdalena","Maguiña","Mahomar","Maikut","Maingot","Mairena","Maisonave","Maita","Majano","Majarres","Malaga","Maldonado","Malé","Malespín","Malestín","Maltés","Maltez","Malvarez","Manavella","Mancheno","Mancia","Mancía","Mandas","Mangaña","Mangas","Mangel","Manjarres","Mans","Mansalvo","Mansilla","Manso","Mantanero","Mantica","Mantilla","Manuel","Manzanal","Manzanares","Manzano","Manzur","Marabiaga","Maradiaga","Marbes","Marbis","Marcenaro","March","Marchena","Marcia","Marcías","Marcillo","Marcos","Mardones","Marenco","Margules","María","Marichal","Marín","Marinero","Marino","Mariñas","Mariño","Marot","Maroto","Marqués","Marquez","Marreco","Marrero","Marroquín","Marsell","Marte","Martell","Martén","Martens","Martí","Martin","Martínez","Martins","Marvez","Mas","Masía","Masís","Maso","Mason","Massuh","Mastache","Mata","Matamoros","Matarrita","Mate","Mateo","Matera","Mateus","Matías","Matos","Mattus","Mattuz","Matul","Matus","Matute","Maurel","Maurer","Mauricio","Mauro","Maynard","Maynaro","Maynart","Mayo","Mayor","Mayorga","Mayorquín","Mayre","Mayrena","Maza","Mazariegos","Mazas","Mazín","Mazón","Mazuque","Mazure","Medal","Mederano","Mederas","Medeiros","Medina","Medinilla","Medoza","Medrano","Meira","Mejía","Mejías","Melara","Meléndez","Melgar","Melgarrejo","Mellado","Melo","Membreño","Mena","Menayo","Menchaca","Mendea","Méndez","Mendiantuba","Mendieta","Mendiola","Mendives","Mendivil","Mendoza","Mendreño","Menéndez","Meneses","Menjibar","Menjivar","Menocal","Meono","Meoño","Merayo","Meraz","Merazo","Merazzo","Mercado","Mercelina","Mercer","Mergarejo","Mérida","Merino","Merizalde","Merlo","Mesa","Mesales","Mesalles","Meseguer","Mesén","Messeguer","Mestayer","Meszaros","Meza","Michelena","Michelino","Micillo","Miguez","Mijangos","Mijares","Milanés","Milano","Millet","Mina","Minas","Minero","Miño","Miqueo","Miraba","Miralles","Mirambell","Miramontes","Miranda","Miro","Mirquez","Mitja","Mitjavila","Mizrachi","Mojarro","Mojica","Molestina","Molian","Molín","Molina","Molinero","Molleda","Mollinedo","Mollo","Moncada","Mondol","Mondragón","Moneda","Moneiro","Monestel","Monga","Mongalo","Móngalo","Monge","Mongillo","Monguillo","Monjarres","Monjarrez","Monjica","Monserrat","Montagné","Montalbán","Montalbert","Montalto","Montalván","Montalvo","Montana","Montanaro","Montandón","Montano","Montealegre","Montealto","Montecino","Montecinos","Monteil","Montejo","Montenaro","Montenegro","Montero","Monterosa","Monteroza","Monterrey","Monterrosa","Monterroso","Montes","Monterinos","Monteverde","Montiel","Montier","Montoya","Monturiol","Mora","Moraes","Moraga","Morales","Morán","Morazán","Moreira","Morejón","Morena","Moreno","Morera","Moriano","Morice","Morillo","Morín","Moris","Morise","Moro","Morote","Moroto","Morraz","Morúa","Morún","Morux","Morvillo","Moscarella","Moscoa","Moscoso","Mosquera","Motta","Moxi","Moya","Mozquera","Mugica","Muiña","Muir","Mulato","Munera","Mungía","Munguía","Munive","Munizaga","Muñante","Muñiz","Muñoz","Murcia","Murgado","Murgas","Murias","Murillo","Murilo","Muro","Mussap","Mussapp","Mussio","Mustelier","MuxoNaim","Naira","Nájar","Nájares","Najarro","Nájera","Nájeres","Naranjo","Narvaes","Narváez","Nasralah","Nasso","Navaro","Navarrete","Navarrette","Navarro","Navas","Nayap","Nazario","Nema","Nemar","Neyra","Nieto","Nino","Niño","Noble","Noboa","Noel","Nogebro","Noguera","Nomberto","Nora","Noriega","Norza","Nova","Novales","Novo","Novoa","Nuevo","Nuez","Nunga","NúñezObaldía","Obanbo","Obando","Obares","Obellón","Obon","Obrego","Obregón","Ocampo","Ocampos","Ocaña","Ocaño","Ocario","Ochoa","Ocón","Oconitrillo","Ode","Odio","Odir","Odóñez","Odor","Oduber","Oguilve","Ojeda","Okarlo","Okendo","Olarte","Olaso","Olaverri","Olazaba","Olguín","Oliva","Olivar","Olivares","Olivárez","Olivas","Oliver","Olivera","Oliverio","Olivier","Oliviera","Olivo","Oller","Olmeda","Olmedo","Olmo","Olmos","Omacell","Omodeo","Ondoy","Onetto","Oñate","Oñoro","Oporta","Oporto","Oquendo","Ora","Orama","Oramas","Orantes","Ordeñana","Ordoñes","Ordóñez","Orduz","Oreamuno","Oreas","Oreiro","Orella","Orellana","Orfila","Orias","Orios","Orjas","Orjuela","Orlich","Ormasis","Ormeño","Orna","Ornes","Orochena","Orocu","Orosco","Orozco","Ortega","Ortegón","Ortiz","Ortuño","Orve","Osante","Oseda","Osegueda","Osejo","Osequeda","Oses","Osorio","Osorno","Ospina","Ospino","Ossa","Otalvaro","Otárola","Otero","Oto","Otoya","Ovares","Ovarez","Oviedo","Ozerio","Ozores","OzunoPabón","Pacheco","Paco","Padilla","Páez","Paguaga","País","Países","Paiz","Pajuelo","Palacino","Palacio","Palacios","Palaco","Paladino","Palazuelos","Palencia","Palma","Palomar","Palomino","Palomo","Pamares","Pampillo","Pana","Pandolfo","Paniagua","Pantigoso","Pantoja","Paña","Papez","Parada","Parado","Parajeles","Parajón","Páramo","Pardo","Paredes","Pareja","Pares","París","Parra","Parrales","Parreaguirre","Parriles","Parrilla","Pasamontes","Pasapera","Pasos","Passapera","Pastor","Pastora","Pastrán","Pastrana","Pastrano","Patiño","Patricio","Paut","Pauth","Pavez","Pavón","Paz","Pazmiño","Pazos","Pedraza","Pedreira","Pedreiro","Pedroza","Peinador","Peinano","Peláez","Pellas","Pellecer","Pena","Penabad","Penado","Pendones","Penón","Penso","Peña","Peñaloza","Peñaranda","Peñas","Peñate","Penzo","Peñón","Peraldo","Perales","Peralta","Peraza","Perdomo","Perea","Perearnau","Pereira","Pereiras","Perera","Pereyra","Pérez","Perezache","Pergo","Pericón","Perla","Perlaza","Pessoa","Peynado","Peytrequín","Pezo","Picado","Picasso","Picavea","Pichardo","Pico","Picón","Piedra","Piedrafita","Pila","Pilarte","Pimente","Pina","Pinada","Pinagel","Pinagen","Pinar","Pincai","Pincay","Pinchinat","Pineda","Pinel","Pinell","Piney","Pinillos","Pinkay","Pino","Pintado","Pinto","Pinzas","Piña","Piñar","Piñate","Piñeiro","Piñeres","Pinzón","Pío","Pion","Piovano","Piovet","Pitalva","Piza","Pizarro","Pla","Plá","Placeres","Pláceres","Plácido","Placidón","Plaja","Platero","Poblador","Poblete","Pocasangre","Pochet","Podoy","Pokoy","Pol","Polamo","Polo","Polonio","Poma","Pomar","Pomareda","Pomares","Ponares","Ponce","Pontigo","Pool","Porat","Porquet","Porras","Porta","Portela","Porter","Portero","Portilla","Portillo","Portobanco","Portocarrera","Portugués","Portuguez","Posada","Posla","Poveda","Povedano","Pozo","Pozos","Pozuelo","Prada","Pradella","Pradilla","Prado","Prat","Pratt","Pravia","Prendas","Prendis","Pretiz","Prettel","Prieto","Prietto","Primante","Prior","Prioto","Privatt","Procupez","Puente","Puentes","Puertas","Puga","Puig","Pujo","Pujol","Pulido","Pulis","Pull","Pulles","Pupo","PurcallasQuedo","Queralt","Queredo","Querra","Quesada","Quevedo","Quezada","Quiel","Quijada","Quijano","Quinaz","Quinde","Quino","Quintana","Quintanilla","Quinter","Quintero","Quinto","Quiñones","Quiñónez","Quirce","Quiroga","Quirós","QuirozRaa","Raabe","Raba","Rabetta","Raga","Raigada","Raigosa","Ramírez","Ramón","Ramos","Randel","Randuro","Rangel","Raphael","Rauda","Raudes","Raudez","Raventos","Raventós","Raygada","Rayo","Rayos","Real","Reales","Reazco","Recinos","Recio","Redondo","Regaño","Regidor","Regueira","Regueyra","Reich","Reina","Renderos","Rendón","Reñazco","Repeto","Repetto","Requene","Requeno","Requeño","Rescia","Resenterra","Restrepo","Retana","Reuben","Revelo","Revilla","Revollar","Revollo","Rey","Reyes","Reyna","Riba","Ribas","Ribera","Ribero","Ricardo","Ricaurte","Riera","Rileva","Rincón","Río","Ríos","Riotte","Rivalta","Rivardo","Rivas","Rivel","Rivera","Rivero","Riverón","Riveros","Rizo","Roa","Roba","Robelo","Roble","Robles","Robleto","Roboz","Roca","Rocabado","Rocca","Roch","Rocha","Roda","Rodas","Rodesma","Rodesno","Rodezno","Rodó","Rodo","Rodrigo","Rodríguez","Roe","Roig","Rois","Rojas","Rojo","Roldán","Romagosa","Román","Romano","Romero","Roque","Rosa","Rosabal","Rosales","Rosas","Rouillón","Rovillón","Rovira","Roviralta","Roy","Royo","Roys","Rozados","Rozo","Ruano","Rubí","Rubia","Rubín","Rubino","Rubio","Rucavado","Rudín","Rueda","Rugama","Rugeles","Ruh","Ruilova","Ruin","Ruiz","Romoroso","RussoSaavedra","Saba","Sabah","Saballo","Saballos","Sabat","Sabate","Sabba","Sabín","Sabogal","Saborío","Saboz","Sacasa","Sacida","Sada","Sadaña","Sáenz","Saer","Saerron","Sáez","Safiano","Sage","Sagel","Sagot","Sagreda","Saguero","Sala","Salablanca","Salamanca","Salas","Salazar","Salbavarro","Salcedo","Salcino","Saldaña","Saldivar","Salgada","Salgado","Salguera","Salguero","Saliba","Salinas","Salmerón","Salmón","Salom","Salomón","Salumé","Salume","Salustro","Salvado","Salvatierra","Salvo","Samaniego","Sambrana","Samper","Samudio","Samuel","SanGil","SanJosé","SanJuan","SanMartín","SanRomán","SanSilvestre","Sanabria","Sanahuja","Saname","Sanamucia","Sanarrusia","Sánchez","Sancho","Sandí","Sandigo","Sandino","Sandoval","Sandria","Sandy","Sanga","Sangil","Sanjines","Sanjuan","Sansebastián","Sansilvestre","Sanson","Sansores","SantaAna","SantaCruz","SantaMaría","Santacruz","Santamaría","Santana","Santander","Santiago","Santibanes","Santiesteban","Santillán","Santín","Santisteban","Santoanastacio","Santos","Sanvicente","Sanz","Saraiva","Saravanja","Saravia","Sardinas","Sardiñas","Sariego","Sarmiento","Sárraga","Sarratea","Sarraulte","Sarria","Sas","Sasso","Satjo","Sauceda","Saucedo","Sauza","Savala","Savallos","Savedra","Savinón","Saxón","Sayaguez","Scriba","Seas","Seballos","Secades","Secaida","Seco","Sedano","Sedo","Segares","Segovia","Segreda","Segura","Sehezar","Selaya","Selles","Selva","Selvas","Semerawno","Semeraro","Sepúlveda","Sequeira","Sermeño","Serra","Serracín","Serrano","Serrato","Serraulte","Serru","Serrut","Servellón","Sevilla","Sevillano","Sibaja","Sierra","Sieza","Sigüenza","Siguenza","Siles","Siliezar","Silva","Silvera","Silvia","Simana","Simón","Sinchico","Sio","Sion","Siri","Sirias","Siverio","","Siz","Sobalvarro","Sobrado","Sojo","Sol","Solana","Solano","Solar","Solares","Solarte","Soldevilla","Solé","Solemne","Soler","Solera","Soley","Solís","Soliz","Solno","Solo","Solórzano","Soltero","Somarriba","Somarribas","Somoza","Soria","Sorio","Soro","Sorto","Sosa","Sossa","Sosto","Sotela","Sotelo","Sotillo","Soto","Sotomayor","Sotres","Souto","Soutullo","Sovalbarro","Soza","Suárez","Suazao","Suazo","Subia","Subiros","Subirós","Subisos","Succar","Sueiras","Suñer","Suñol","Surroca","Suyapa","SuzarteTabah","Tabares","Tablada","Tabor","Tabora","Taborda","Taco","Tagarita","Tagarró","Tal","Talavera","Taleno","Tamara","Tamargo","Tamayo","Tames","Tanchez","Tanco","Tapia","Tapias","Taracena","Tardencilla","Tarjan","Tarrillo","Tasara","Tate","Tato","Tavares","Tedesco","Teherán","Teijeiro","Teixido","Tejada","Tejeda","Tejos","Tellería","Telles","Téllez","Tello","Tellos","Tencio","Tenorio","Terán","Tercero","Terrade","Terrientes","Terrin","Terrín","Thames","Theran","Thiel","Thiele","Thuel","Tíjeres","Tijerino","Tinoco","Toala","Tobal","Tobar","Tobe","Tobella","Tobín","Tobón","Toledo","Toletino","Tomas","Tomás","Tomeu","Toribio","Torijano","Tormo","Toro","Torralba","Torre","Torrealba","Torregresa","Torregroza","Torrente","Torrentes","Torres","Tórrez","Tortós","Tortosa","Toruño","Tosso","Touma","Toval","Tovar","Trala","Traña","Traures","Travierzo","Travieso","Trediño","Treguear","Trejos","Treminio","Treviño","Triana","Trigo","Triguel","Triguero","Trigueros","Trilite","Trimarco","Trimiño","Triquell","Tristán","Triunfo","Troche","Trocanis","Troncoso","Troya","Troyo","Troz","Trueba","Truffat","Trujillo","Trullas","Trullás","Truque","Tula","Turcio","TurciosUbach","Ubao","Ubeda","Ubico","Ubilla","Ubisco","Ubizco","Ucanan","Ucañan","Ugalde","Ugarte","Ujueta","Ulacia","Ulate","Ulcigrai","Ulcigral","Ulecia","Uley","Ulibarri","Ulloa","Umaña","Umanzor","Ungar","Urain","Uralde","Urbano","Urbina","Urcuyo","Urdangarin","Urea","Urela","Ureña","Urgellés","Uriarte","Uribe","Uriel","Urieta","Uriza","Uroz","Urquiaga","Urra","Urraca","Urrea","Urroz","Urruela","Urrutia","Urtecho","Urunuela","Urzola","Usaga","Useda","Uva","Uveda","Uzaga","UzcateguiVadivia","Vado","Valdelomar","Valderama","Valderrama","Valderramo","Valderramos","Valdés","Valdescastillo","Valdez","Valdiva","Valdivia","Valdivieso","Valencia","Valenciano","Valentín","Valenzuela","Valera","Valerín","Valerio","Vales","Valiente","Valladares","Vallarino","Vallcaneras","Valldeperas","Valle","Vallecillo","Vallecillos","Vallejo","Vallejos","Valles","Vallez","Valls","Vals","Valverde","Vanegas","Vaquerano","Vardesia","Varela","Varga","Vargas","Vargo","Varsi","Varsot","Vartanian","Varth","Vasco","Vasconcelos","Vasílica","Vásquez","Vassell","Vaz","Veas","Vedoba","Vedova","Vedoya","Vega","Vegas","Vela","Velarde","Velasco","Velásquez","Velazco","Velázquez","Vélez","Veliz","Venegas","Ventura","Vera","Verardo","Verastagui","Verdesia","Verdesoto","Vergara","Verguizas","Vertiz","Verzola","Vesco","Viales","Viana","Viatela","Vicario","Vicente","Vico","Víctor","Victores","Victoria","Vidaechea","Vidal","Vidales","Vidalón","Vidaorreta","Vidaurre","Videche","Vieira","Vieto","Vigil","Vigot","Vila","Vilaboa","Vilallobos","Vilanova","Vilaplana","Villar","Villareal","Villarebia","Villareiva","Villarreal","Villarroel","Villas","Villaseñor","Villasuso","Villatoro","Villaverde","Villavicencio","Villeda","Villegas","Villejas","Villena","Viloria","Vindas","Vindel","Vinueza","Viñas","Víquez","Viscaino","Viso","Vivallo","Vivas","Vivero","Vives","Vívez","Vivies","Vivó","Vizcaíno","VizcaynoWainberg","WolfXatruch","Xirinachs","XiquesYaacobi","Yanarella","Yanayaco","Yanes","Yepez","Yglesias","Yllanes","Yurica","YzaguirreZabala","Zabaleta","Zabate","Zablah","Zacarías","Zacasa","Zalazar","Zaldivar","Zallas","Zambrana","Zambrano","Zamora","Zamorano","Zamudio","Zamuria","Zapata","Zaragoza","Zárate","Zarco","Zaror","Zarzosa","Zavala","Zavaleta","Zayas","Zayat","Zecca","Zedan","Zegarra","Zelada","Zelaya","Zeledón","Zepeda","Zetina","Zonta","Zoratte","Zuleta","Zumba","Zumbado","Zúñiga","Zunzunegui" };
        var posicion = new Random().Next(0,listaApellidos.Count - 1);
        return listaApellidos[posicion];
      } catch (Exception e) {
        throw new Exception("Error al intentar generar un apellido aleatorio.",e);
      }
    }

    /// <summary>
    /// Método encargado de generar una fecha de nacimiento de manera aleatoria, con edad entre 1 y 130 años.
    /// </summary>
    /// <exception cref="Exception.Exception(string, Exception)">Se genera en caso de fallar la ejecución del método</exception>
    /// <returns></returns>
    public DateTime RandomFechaNacimiento() {
      try {
        var fechaNacimiento = this.RandomFechaNacimiento(DataGeneration.EDAD_MINIMA,DataGeneration.EDAD_MAXIMA);
        return fechaNacimiento;
      } catch (Exception e) {
        throw new Exception("Error al intentar generar una fecha de nacimiento aleatoria.",e);
      }
    }

    /// <summary>
    /// Método encargado de generar una fecha de nacimiento de manera aleatoria, con edad entre los parámetros enviados.
    /// </summary>
    /// <param name="_edadInicio">Edad de inicio para la fecha de nacimiento</param>
    /// <param name="_edadTermino">Edad de término para la fecha de nacimiento</param>
    /// <returns></returns>
    public DateTime RandomFechaNacimiento(int _edadInicio,int _edadTermino) {
      try {
        if (_edadInicio < DataGeneration.EDAD_MINIMA) {
          throw new ArgumentException("Error, la edad mínima enviada es menor a la permitida (1 año).");
        }
        if (_edadTermino > DataGeneration.EDAD_MAXIMA) {
          throw new ArgumentException("Error, la edad máxima enviada es mayor a la permitida (130 años)");
        }
        if (_edadInicio > _edadTermino) {
          throw new ArgumentException("Error, la edad mínima enviada es mayor a la edad máxima enviada.");
        }
        var fechaResta = new Random().Next(_edadInicio,_edadTermino);
        var fechaActual = DateTime.UtcNow;
        var fechaNacimiento = fechaActual.AddYears(-fechaResta);
        return fechaNacimiento;
      } catch (Exception e) {
        throw new Exception("Error al intentar generar una fecha de nacimiento aleatoria, entre los límites enviados por parámetro.",e);
      }
    }

    /// <summary>
    /// Método encargado de retornar un número telefónico aleatorio, entre 30000000 y 99999999.
    /// </summary>
    /// <returns></returns>
    public string RandomTelefono() {
      var numero = new Random().Next(DataGeneration.TELEFONO_MINIMO,DataGeneration.TELEFONO_MAXIMO);
      return $"+56 9 {numero}";
    }

    /// <summary>
    /// Método encargado de retornar un correo electrónico aleatorio, con un nombre, apellido y dominio predefinido u opcional.
    /// </summary>
    /// <param name="_nombre">Nombre que formará parte del correo electrónico</param>
    /// <param name="_apellido">Apellido que formará parte del correo electrónico</param>
    /// <param name="_dominio">Dominio del correo electrónico</param>
    /// <exception cref="Exception.Exception(string, Exception)">Se genera en caso de fallar la ejecución del método</exception>
    /// <returns></returns>
    public string RandomCorreo(string _nombre = null,string _apellido = null,string _dominio = "example.com") {
      try {
        if (string.IsNullOrEmpty(_dominio) == true || string.IsNullOrWhiteSpace(_dominio) == true) {
          throw new ArgumentNullException("Error, dominio no válido.");
        }
        if (string.IsNullOrEmpty(_nombre) == true || string.IsNullOrWhiteSpace(_nombre) == true) {
          _nombre = this.RandomNombre();
        }
        if (string.IsNullOrEmpty(_apellido) == true || string.IsNullOrWhiteSpace(_apellido) == true) {
          _apellido = this.RandomApellido();
        }
        return $"{_nombre}.{_apellido}@{_dominio}";
      } catch (Exception e) {
        throw new Exception("Error al intentar generar un correo aleatorio.");
      }
    }
  }
}

# GroceryApp sprint4 Studentversie

## GitFlow Workflow

Dit project maakt gebruik van een aangepaste GitFlow-structuur.  
Hieronder staat uitgelegd hoe we met branches werken en hoe je nieuwe code toevoegt.

### Branches
- **main**  
  Bevat de stabiele productiecode. Alleen releases en hotfixes komen hier terecht.

- **develop**  
  Hier wordt alle ontwikkelcode samengebracht vanuit feature-branches.  
  Beschouw dit als de "werkversie" die klaarstaat voor de volgende release.

- **release/**  
  Wordt pas aangemaakt als de develop branch stabiel genoeg is om een release te maken.  
  Bijvoorbeeld: `release/release-v1.0.0`.

- **feature/**  
  Elke nieuwe feature of use case krijgt zijn eigen branch.  
  Bijvoorbeeld:
    - `feature/UC05`
    - `feature/UC06`

- **hotfix/**  
  Wordt gebruikt om dringende fixes te doen op productiecode.  
  Bijvoorbeeld: `hotfix/hotfix-v1.0.1`.
  Deze word vanuit de main branch gemaakt en na afronding gemerged naar zowel main als develop.

## UC10 Productaantal in boodschappenlijst
Aanpassingen zijn compleet.

## UC11 Meest verkochte producten
Vereist aanvulling:  
- Werk in GroceryListItemsService de methode GetBestSellingProducts uit.  
- In BestSellingProductsView de kop van de tabel aanvullen met de gewenste kopregel boven de tabel. Daarnaast de inhoud van de tabel uitwerken.

## UC13 Klanten tonen per product  
Deze UC toont de klanten die een bepaald product hebben gekocht:  
- Maak enum Role met als waarden None en Admin.  
- Geef de Client class een property Role metb als type de enum Role. De default waarde is None.  
- In Client Repo koppel je de rol Role.Admin aan user3 (= admin).
- In BoughtProductsService werk je de Get(productid) functie uit zodat alle Clients die product met productid hebben gekocht met client, boodschappenlijst en product in de lijst staan die wordt geretourneerd.  
- In BoughtProductsView moet de naam van de Client ewn de naam van de Boodschappenlijst worden getoond in de CollectionView.  
- In BoughtProductsViewModel de OnSelectedProductChanged uitwerken zodat bij een ander product de lijst correct wordt gevuld.  
- In GroceryListViewModel maak je de methode ShowBoughtProducts(). Als de Client de rol admin heeft dan navigeer je naar BoughtProductsView. Anders doe je niets.  
- In GroceryListView voeg je een ToolbarItem toe met als binding Client.Name en als Command ShowBoughtProducts.  


  

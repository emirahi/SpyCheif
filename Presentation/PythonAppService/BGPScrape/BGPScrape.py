
import requests
from bs4 import BeautifulSoup

class BGPScrape:

    def __init__(self,url):
        self.url = url
        self.session = requests.session()
        self.items = {}
        self.options = {}

    def SetUrl(self,url):
        self.url = url

    def ScrapeTable(self):

        rsp = self.session.get(self.url)
        if rsp.status_code == 200:
            soup = BeautifulSoup(rsp.content,"html.parser")
            trows = soup.select(".w100p tbody tr")
            for trow in trows:
                path = trow.select_one("a")["href"]
                url = "https://bgp.he.net" + path
                title = trow.select_one("a").text.strip()
                typee = trow.select_one("td:nth-child(2)").text.strip()
                description = trow.select_one("td:nth-child(3)").text.strip()
                print(path,title,typee,description,sep="\t")
                try:
                    records = self.items[typee]
                    records.append({"title":title,"description":description})
                except KeyError:
                    self.items.update({typee:[{"title":title,"description":description}]})
                
                    

if __name__ == "__main__":
    url = "https://bgp.he.net/search?search%5Bsearch%5D=booking&commit=Search"
    bgp = BGPScrape(url)
    bgp.Scrape()



class Buyer {
    constructor(buyer) {
        this.buyerId = buyer.buyerId;
        this.buyerName = buyer.buyerName;
        this.buyerMail = buyer.buyerMail;
        this.toHTML();
    }
    toHTML() {
        this.main = document.createElement("div");
        let body = document.createElement("div");

        let buyer_id = document.createElement("p");
        let buyer_name = document.createElement("p");
        let buyer_mail = document.createElement("p");
        

        this.main.id = "buyer_" + this.buyerId;
        this.main.className = "card m-1";
        this.main.style.backgroundColor = "white";

        body.className = "card-body";
        buyer_mail.style.float = "left";
        
        buyer_id.textContent = "Buyer Id: " + this.buyerId;
        buyer_name.textContent = "Buyer Full Name: " + this.buyerName;
        buyer_mail.textContent = "Buyer Contact Email: " + this.buyerMail;

        body.appendChild(buyer_id);
        body.appendChild(buyer_name);
        body.appendChild(buyer_mail);

        this.main.appendChild(body);
    }
    getHTML() {
        console.log(this.main);
        return this.main;
    }
    isSelected() {
        return this.isSelected;
    }
    
} 

// test amaçlı
let buyer1 = {
    buyer_id: 1,
    buyer_name: "Tarık Can Şahin",
    buyer_mail: "1999tarik1999@gmail.com"
}
let buyer2 = {
    buyer_id: 5,
    buyer_name: "Lionel Messi",
    buyer_mail: "1999messi1999@gmail.com"
}
let buyer3 = {
    buyer_id: 29,
    buyer_name: "Pablo Escobar",
    buyer_mail: "1999escobar1999@gmail.com"
}
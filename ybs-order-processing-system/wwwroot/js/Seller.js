class Seller {
    constructor(seller) {
        this.sellerId = seller.sellerId;
        this.sellerName = seller.sellerName;
        this.sellerPhoneNum = seller.sellerPhoneNum;
        this.sellerMail = seller.sellerMail;
        this.sellerAddress = seller.sellerAddress;
        this.toHTML();
    }
    toHTML() {
        this.main = document.createElement("div");
        let body = document.createElement("div");

        let seller_id = document.createElement("p");
        let seller_name = document.createElement("p");
        let seller_phone_num = document.createElement("p");
        let seller_mail = document.createElement("p");
        let seller_address = document.createElement("p");
        let button = document.createElement("button");


        this.main.id = "seller_" + this.sellerId;
        this.main.className = "card m-1";

        body.className = "card-body";
        seller_address.style.float = "left";
        button.style.float = "right";
        button.className = "btn btn-primary";

        seller_id.textContent = "Seller Id: " + this.sellerId;
        seller_name.textContent = "Seller Name: " + this.sellerName;
        seller_phone_num.textContent = "Seller Phone Number: " + this.sellerPhoneNum;
        seller_mail.textContent = "Seller Contact Mail: " + this.sellerMail;
        seller_address.textContent = "Seller Address: " + this.sellerAddress;
        
        button.textContent = "Suspend seller";

        body.appendChild(seller_id);
        body.appendChild(seller_name);
        body.appendChild(seller_phone_num);
        body.appendChild(seller_mail);
        body.appendChild(seller_address);
        body.appendChild(button);

        button.onclick = () => {
            this.isSelected = true;
            this.main.remove();
            deleteSeller();
            $.ajax({
                cache: false,
                type: 'GET',
                url: '/Home/DeleteSeller?sellerId=' + this.sellerId,
                success: function (response) {
                    location.reload();
                }
            })
        };

        this.main.appendChild(body);
    }
    getHTML() {
        console.log(this.main);
        return this.main;
    }
    deleteHTML() {
        delete this.main;
    }
    getId() {
        return this.seller_id;
    }
}

// test amaçlı
let seller1 = {
    seller_id: 1,
    seller_name: "Nihad Guluzade",
    seller_phone_num: "+90 234 23 32",
    seller_mail: "nihad_guluzade@gmail.com",
    seller_address: "Bakü"
}
let seller2 = {
    seller_id: 2,
    seller_name: "Leman Valizada",
    seller_phone_num: "+90 224 53 80",
    seller_mail: "leman_valizda@gmail.com",
    seller_address: "İstanbul"
}
let seller3 = {
    seller_id: 3,
    seller_name: "Ahmet Aslan",
    seller_phone_num: "+90 224 22 23",
    seller_mail: "ahmet_aslan@gmail.com",
    seller_address: "İstanbul"
}
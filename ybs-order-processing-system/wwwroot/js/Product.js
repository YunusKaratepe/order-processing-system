class Product {
    constructor(product) {
        console.log(product);
        this.productId = product.productId;
        this.productName = product.productName;
        this.productPrice = product.productPrice;
        // this.productCategoryId = product.productCategoryId;
        this.productCategory = product.productCategory;
        this.toHTML();
    }
    toHTML() {
        this.main = document.createElement("div");
        let body = document.createElement("div");

        let product_id = document.createElement("p");
        let product_name = document.createElement("p");
        let product_price = document.createElement("p");
        let product_category_id = document.createElement("p");
        let product_category_name = document.createElement("p");
        
        this.main.id = "product_" + this.productId;
        this.main.className = "card m-1";

        body.className = "card-body";
        product_category_name.style.float = "left";

        product_id.textContent = "Product Id: " + this.productId;
        product_name.textContent = "Product Name: " + this.productName;
        product_price.textContent = "Product Price: " + this.productPrice;
        //product_category_id.textContent = "Product Category Id: " + this.productCategoryId;
        product_category_name.textContent = "Product Category Name: " + this.productCategory;


        body.appendChild(product_id);
        body.appendChild(product_name);
        body.appendChild(product_price);
        body.appendChild(product_category_id);
        body.appendChild(product_category_name);


        this.main.appendChild(body);
    }
    getHTML() {
        console.log(this.main);
        return this.main;
    }
   
}

// test amaçlı
let product1 = {
    product_id: 132,
    product_name: "Logitech Klavye",
    product_price: 220.50,
    product_category_id: 2,
    product_category_name: "Teknoloji"
}
let product2 = {
    product_id: 1,
    product_name: "Oyuncu Terliği",
    product_price: 30.90,
    product_category_id: 2,
    product_category_name: "Teknoloji"
}
let product3 = {
    product_id: 1684,
    product_name: "Olasılıksız",
    product_price: 25.90,
    product_category_id: 26,
    product_category_name: "Kitap"
}
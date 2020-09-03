function expandNav() {
    document.querySelector(".nav-expand").classList.toggle("expand");
    const btn = document.querySelector(".nav-expand-btn").children;

    for (var i = 0; i < btn.length; i++) {
        btn[i].classList.toggle("expand");
    }
}

//$(".nav-expand-btn").click(() => {

//    $(".first-line").toggleClass("first-line-true");
//    $(".second-line").toggleClass("second-line-true");
//    $(".third-line").toggleClass("third-line-true");
//});

function alterCakeType(type) {
    if (type === "boutique") {
        document.getElementsByClassName("cake-type-description")[0]
            .innerHTML = `Butik pastalarımız geleneksel pastalardan farklı olarak,
                              sizlerin gönderdiği resimlere göre hazırlanmaktadır.
                              Dilediğiniz şekil, logo, resim şeker hamuru kullanılarak pastanıza görüntü kazandırmaktayız.
                              Ödemeye geçmeden önce fotoğraf yüklediğinizden emin olunuz.`;
        document.getElementsByClassName("boutique-cake-picture")[0]
            .classList.remove("hide");
    } else {
        document.getElementsByClassName("cake-type-description")[0]
            .innerHTML = `Kremalı pastalarımız sağlıklı ve taze malzemelerle, seçtiğiniz seçeneklere göre gününde hazırlanmaktadır.`
        document.getElementsByClassName("boutique-cake-picture")[0]
            .classList.add("hide");
    }
}

function handlePrice() {
    let priceInput = document.getElementById("Order_Price");
    let price = document.getElementById("price");
    let size = document.getElementById("Order_CakeSize");
    let typeBoutique = document.getElementById("boutique-cake");
    let typeCream = document.getElementById("cream-cake");

    size.addEventListener("change", changePrice);
    typeBoutique.addEventListener("change", changePrice);
    typeCream.addEventListener("change", changePrice);

    function changePrice() {
        priceInput.value = 0;
        price.innerHTML = 0;

        if (typeCream.checked) {
            priceInput.value = 100;
            price.innerHTML = 100;
        } else if (typeBoutique.checked) {
            priceInput.value = 150;
            price.innerHTML = 150;
        }

        if (!isNaN(Number(size.value)) && Number(size.value) > 3) {
            priceInput.value = Number(priceInput.value) + (Number(size.value) * 10);
            price.innerHTML = Number(price.innerHTML) + (Number(size.value) * 10);
        }
    }
}

function activeOwlCarousel() {
    $('.owl-carousel').owlCarousel({
        loop: false,
        nav: true,
        center: false,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            }

        }
    });

    $(".owl-next span").html("<i class='fas fa-chevron-right'></i>");
    $(".owl-prev span").html("<i class='fas fa-chevron-left'></i>");
}

function changePaymentType(type) {
    if (type === "credit") {
        document.querySelector(".credit-card-form").style.display = "block";
    } else {
        document.querySelector(".credit-card-form").style.display = "none";
    }
}
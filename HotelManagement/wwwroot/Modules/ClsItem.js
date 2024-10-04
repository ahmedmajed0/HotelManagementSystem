let Items = [];


let ClsItem = {
    GetItems: function () {

        Helper.AjaxCallGet("/api/FoodApi", {}, "json", function (data) {
            Items = data;

            let htmlData = "";
            for (let i = 0; i < data.length; i++) {
                htmlData = htmlData + ClsItem.Template1(data[i]);
            }
            
            $("#DivTemplate1").html(htmlData);

        },

            function () {

            },
         )
    },




    ItemsFilter: function (catId) {
        let newItems = $.grep(Items, function (n, i) { // just use arr
            return n.categoryId === catId;
        });

        let htmlData = "";
        for (let i = 0; i < newItems.length; i++) {
            htmlData = htmlData + ClsItem.Template1(newItems[i]);
        }

        $("#DivTemplate1").html(htmlData);


    },

    Template1: function (item) {
        let itemHtml = "<div class='product product__style--3 col-lg-4 col-md-4 col-sm-6 col-12'>";
        itemHtml = itemHtml + "<div class='product__thumb'>";
        itemHtml = itemHtml + "<a class='first__img' href='/Food/SingleFood?id=" + item.foodId + "'> <img src='/Uploads/" + item.foodImage + "' height=" + 270 + " width=" + 340 +" alt='product image'></a>";
        itemHtml = itemHtml + "<a class='second__img animation1' href='/Food/SingleFood?id=" + item.foodId + "'><img src='/Uploads/" + item.foodImage + "' height="+ 270 +" width="+ 340 +" alt='product image'></a>";
        itemHtml = itemHtml + "<div class='hot__box'>";
        itemHtml = itemHtml + "<span class='hot-label'>" + item.categoryName + "</span> </div> </div>";
        itemHtml = itemHtml + "<div class='product__content content--center'>";
        itemHtml = itemHtml + "<h4><a href='/Food/SingleFood?id=" + item.foodId + "'>" + item.foodName + "</a></h4>";
        itemHtml = itemHtml + "<ul class='prize d-flex'>";
        itemHtml = itemHtml + "<li>" + item.foodPrice + "</li>";
        itemHtml = itemHtml + "</ul>";
        itemHtml = itemHtml + " <div class='action'>";
        itemHtml = itemHtml + "<div class='actions_inner'>";
        itemHtml = itemHtml + "<ul d-flex justify-content-center'>";
        itemHtml = itemHtml + "<li><a class='btn btn-primary btn-sm pr-3 text-white' href='/Food/SingleFood?id=" + item.foodId + "'>More Details</a></li>";
        itemHtml = itemHtml + "</ul> </div> </div>";
        itemHtml = itemHtml + "</div></div></div></div>";

        return itemHtml;
    },

}

ClsItem.GetItems();

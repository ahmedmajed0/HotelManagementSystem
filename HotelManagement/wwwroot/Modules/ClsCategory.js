let ClsCategory = {
    LoadCategories: function () {
        Helper.AjaxCallGet("/api/CategoryApi", {}, "json", function (data) {
            let htmlData = "";


            for (let i = 0; i < data.length; i++) {
                htmlData = htmlData + ClsCategory.Template1(data[i]);
            }

            $("#DivLoadCategory").html(htmlData);

        },
            function () {

            }
        )
    },

    Template1: function (cat) {
        let category = "<li><a onclick='ClsItem.ItemsFilter(" + cat.categoryId + ")'>" + cat.categoryName + " <span>" + cat.availableCategories+"</span></a></li>";
        return category;
    }
}

ClsCategory.LoadCategories();
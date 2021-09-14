//chekbox for agency
$("#anyId").on("change", function (e) {
	e.preventDefault();
	console.log(e)
	if ($(this).is(':checked')) {
		$("#createacc").css("display", "block");
	}
	else {
		$("#createacc").css("display", "none");
	}
});






const navToggle = document.querySelector(".nav-toggle");
const links = document.querySelectorAll(".nav-menu");


navToggle.addEventListener("click", () => {
	links.forEach(el => {
		el.classList.toggle("show-links");
	});
});

window.addEventListener("resize", () => links.classList.remove("show-links"));



//load more
$(".loadmore").on("click", function (e) {
    e.preventDefault();

    var id = $(this).attr("data-id");
    var nextPage = $(this).attr("data-nextpage");

    console.log(id + "  " + nextPage);

    $.ajax({
        url: "/properties/LoadMore?propertyId=" + id + "&page=" + nextPage,
        type: "get",
        dataType: "json",
        //data: {
        //    propertyId:id,
        //},
        success: function (response) {
            console.log(response)

            let ul = $(".loading");
            ul.empty();
            for (var i = 0; i < response.length; i++) {
                let comment = 


                    '<li class="article_comments_wrap">'+
                        '<article>'+
                            //'<div class="article_comments_thumb">'
                            //    '<img src="~/Uploads/Images/@item.MyProfileForAgents.ProfileImage" alt="">'
                            // '</div>'
                                '<div class="comment-details">'+
                                    '<div class="comment-meta">'+
                                        '<div class="comment-left-meta">'+
                                              '<h4 class="author-name">' + response[i].ownername+'</h4>'+
                                             '<div class="comment-date">' + response[i].addeddate +'</div>'+
                                        '</div>'+
                                  '</div>'+
                                    '<div class="comment-text">'+
                                        '<p>' + response[i].content +'</p>'
                                    '</div>'
                                '</div>'
                           '</article>'
                        '</li>'
                ul.append(comment)
            }

        },
        error: function (response) {
            console.log("Err: " + response)
        }
    });
});
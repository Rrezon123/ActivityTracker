// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// function $(selector) {
// 	return document.querySelector(selector)
// }

// function find(el, selector) {
// 	let finded
// 	return (finded = el.querySelector(selector)) ? finded : null
// }

// function siblings(el) {
// 	const siblings = []
// 	for (let sibling of el.parentNode.children) {
// 		if (sibling !== el) {
// 			siblings.push(sibling)
// 		}
// 	}
// 	return siblings
// }

// const showAsideBtn = $('.show-side-btn')
// const sidebar = $('.sidebar')
// const wrapper = $('#wrapper')

// showAsideBtn.addEventListener('click', function () {
// 	$(`#${this.dataset.show}`).classList.toggle('show-sidebar')
// 	wrapper.classList.toggle('fullwidth')
// })

// if (window.innerWidth < 767) {
// 	sidebar.classList.add('show-sidebar');
// }

// window.addEventListener('resize', function () {
// 	if (window.innerWidth > 767) {
// 		sidebar.classList.remove('show-sidebar')
// 	}
// })

// $('.sidebar .close-aside').addEventListener('click', function () {
// 	$(`#${this.dataset.close}`).classList.add('show-sidebar')
// 	wrapper.classList.remove('margin')
// })



var TeamDetailPostBackURL = '/Home/ShowPartial';  
$(function () {  
	$(".anchorDetail").click(function () {  
		debugger;  
		var $buttonClicked = $(this);  
		var id = $buttonClicked.attr('data-id');  
		var options = { "backdrop": "static", keyboard: true };  
		$.ajax({  
			type: "GET",  
			url: TeamDetailPostBackURL,  
			contentType: "application/json; charset=utf-8",  
			data: { "todoid": id },  
			datatype: "json",  
			success: function (data) {  
				debugger;  
				$('#ModalContent').html(data);  
				// $('#ShowMore').modal(options);  
				$('#ShowMore').modal('show');                    

			},  
			error: function () {  
				alert("Dynamic content load failed.");  
			}  
		});  
	});          
});  

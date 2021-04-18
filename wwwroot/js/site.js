// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function $(selector) {
	return document.querySelector(selector)
}

function find(el, selector) {
	let finded
	return (finded = el.querySelector(selector)) ? finded : null
}

function siblings(el) {
	const siblings = []
	for (let sibling of el.parentNode.children) {
		if (sibling !== el) {
			siblings.push(sibling)
		}
	}
	return siblings
}

const showAsideBtn = $('.show-side-btn')
const sidebar = $('.sidebar')
const wrapper = $('#wrapper')

showAsideBtn.addEventListener('click', function () {
	$(`#${this.dataset.show}`).classList.toggle('show-sidebar')
	wrapper.classList.toggle('fullwidth')
})

if (window.innerWidth < 767) {
	sidebar.classList.add('show-sidebar');
}

window.addEventListener('resize', function () {
	if (window.innerWidth > 767) {
		sidebar.classList.remove('show-sidebar')
	}
})

$('.sidebar .close-aside').addEventListener('click', function () {
	$(`#${this.dataset.close}`).classList.add('show-sidebar')
	wrapper.classList.remove('margin')
})



$('#ShowMore').on('show.bs.modal', function (event) {
	var button = $(event.relatedTarget) // Button that triggered the modal
	var recipient = button.data('whatever') // Extract info from data-* attributes
	// If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
	// Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
	var modal = $(this)
	modal.find('.modal-title').text('New message to ' + recipient)
	modal.find('.modal-body input').val(recipient)
  })
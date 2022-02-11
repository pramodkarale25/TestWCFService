function getAllHeroes() {
	$.ajax({
		url: "Service/JSONServiceTrialNError.svc/GetAllHeros",
		type: "GET",
		dataType: "json",
		success: function (result) {
			heroes = result;
			drawHeroTable(result);
		}
	});
}

function addHero() {

	var newHero = {
		"FirstName": $("#addFirstname").val(),
		"LastName": $("#addLastname").val(),
		"HeroName": $("#addHeroname").val(),
		"PlaceOfBirth": $("#addPlaceOfBirth").val(),
		"Combat": $("#addCombatPoints").val()
	}

	$.ajax({
		url: "Service/JSONService.svc/AddHero",
		type: "POST",
		dataType: "json",
		contentType: "application/json",
		data: JSON.stringify(newHero),
		success: function (result) {
			showOverview();
		}
	});
}

function putHero() {
	updateHero.FirstName = $("#updateFirstname").val();
	updateHero.LastName = $("#updateLastname").val();
	updateHero.HeroName = $("#updateHeroname").val();
	updateHero.PlaceOfBirth = $("#updatePlaceOfBirth").val();
	updateHero.Combat = $("#updateCombatPoints").val();

	$.ajax({
		url: "Service/JSONService.svc/UpdateHero/" + updateHero.Id,
		type: "PUT",
		dataType: "json",
		contentType: "application/json",
		data: JSON.stringify(updateHero),
		success: function (result) {
			showOverview();
		}
	});
}

function deleteHero(heroId) {
	$.ajax({
		url: "Service/JSONService.svc/DeleteHero/" + heroId,
		type: "DELETE",
		dataType: "json",
		success: function () {
			getAllHeroes();
		}
	});
}

function searchHero() {
	var searchText = $("#searchText").val();

	$.ajax({
		url: "Service/JSONService.svc/SearchHero/" + searchText,
		type: "GET",
		dataType: "json",
		success: function (result) {
			heroes = result;
			drawHeroTable(heroes);
		}
	});
}

function sortedHeroList(Type) {
	$.ajax({
		url: "Service/JSONService.svc/GetSortedHero/" + Type,
		type: "GET",
		dataType: "json",
		success: function (result) {
			heroes = result;
			drawHeroTable(heroes);
		}
	});
}

function fight() {
	var id1 = $("#fighter1").val();
	var id2 = $("#fighter2").val();

	$.ajax({
		url: "Service/JSONService.svc/Fight/" + id1 + "/" + id2,
		type: "GET",
		dataType: "json",
		success: function (result) {
			$("#fightResult").html(result);
		}
	});
}
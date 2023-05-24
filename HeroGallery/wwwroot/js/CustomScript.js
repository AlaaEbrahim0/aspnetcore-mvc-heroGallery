function confirmDelete(userId, isDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + userId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + userId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    }
    else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}
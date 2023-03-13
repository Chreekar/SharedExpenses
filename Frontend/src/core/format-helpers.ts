export function formatMonth(month: number) {
    return new Date(2000, month, 1).toLocaleString("default", {
        month: "long",
    });
}

export function formatMoney(value: number) {
    return new Intl.NumberFormat("sv-SE", {
        style: "currency",
        currency: "SEK",
        minimumFractionDigits: 0,
        maximumFractionDigits: 0,
    }).format(value);
}
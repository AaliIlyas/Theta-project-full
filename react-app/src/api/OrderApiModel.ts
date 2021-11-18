export interface OrderApiModel {
    orderId: number;
    date: Date;
    customer: {
        customerId: number;
        firstName: string;
        lastName: string;
    },
    product: {
        productId: number;
        name: string;
        price: number
    }
}
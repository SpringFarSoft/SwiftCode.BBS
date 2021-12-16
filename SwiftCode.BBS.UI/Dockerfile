FROM node:14.13.1-slim as builder

WORKDIR /app

COPY . .

FROM nginx:1.19.6

COPY ["./_nginx/default.conf", "/etc/nginx/nginx.conf"]

RUN rm -rf /usr/share/nginx/html/*

COPY --from=builder /app /usr/share/nginx/html

CMD [ "nginx", "-g", "daemon off;"]
